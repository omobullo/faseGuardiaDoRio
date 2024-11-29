using System.Collections;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        private LifeManager lifeManager; // Referência ao LifeManager no Canvas

        public override void Execute()
        {
            var player = model.player;
            if (lifeManager == null)
            {
                // Encontrar o LifeManager na cena
                lifeManager = GameObject.FindObjectOfType<LifeManager>();
            }

            if (player.health.IsAlive)
            {
                player.health.Die();

                if (lifeManager != null)
                {
                    lifeManager.LoseLife();
                }

                model.virtualCamera.m_Follow = null;
                model.virtualCamera.m_LookAt = null;
                player.controlEnabled = false;

                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                player.animator.SetTrigger("hurt");
                player.animator.SetBool("dead", true);

                if (player.health.currentLives > 0)
                {
                    Simulation.Schedule<PlayerSpawn>(2);
                }
                else
                {
                    Debug.Log("Game Over! No more lives left.");
                }
            }
        }
    }
}
