using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represents the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 1;

        /// <summary>
        /// The maximum number of lives.
        /// </summary>
        public int maxLives = 3;

        /// <summary>
        /// Current number of lives.
        /// </summary>
        public int currentLives;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0 && currentLives > 0;

        int currentHP;

        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            if (currentHP == 0)
            {
                LoseLife();
                if (currentLives > 0)
                {
                    ResetHP();
                }
                else
                {
                    var ev = Schedule<HealthIsZero>();
                    ev.health = this;
                }
            }
        }

        /// <summary>
        /// Decrement the HP of the entity until HP reaches 0.
        /// </summary>
        public void Die()
        {
            while (currentHP > 0) Decrement();
        }

        /// <summary>
        /// Reset HP to the maximum value.
        /// </summary>
        public void ResetHP()
        {
            currentHP = maxHP;
        }

        /// <summary>
        /// Lose a life and emit GameOver if lives reach 0.
        /// </summary>
        public void LoseLife()
        {
            currentLives--;
            if (currentLives <= 0)
            {
                Debug.Log("Game Over! No more lives left.");
                // Implement Game Over logic here, if needed.
            }
        }

        void Awake()
        {
            currentHP = maxHP;
            currentLives = maxLives;
        }
    }
}
