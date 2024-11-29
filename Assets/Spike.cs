using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int damage = 1; // Quantidade de dano que o Spike causa

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que colidiu tem o script "PlayerHealth"
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            // Reduz o HP do Player
            playerHealth.TakeDamage(damage);
        }
    }
}