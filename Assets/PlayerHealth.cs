using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5; // Vida máxima do Player
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; // Define a vida inicial
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida atual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player morreu!");
        // Aqui você pode adicionar lógica para reiniciar a cena, mostrar a tela de Game Over, etc.
    }
}
