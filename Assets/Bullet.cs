using UnityEngine;
using Platformer.Mechanics; // Importa o namespace do EnemyController

public class Bullet : MonoBehaviour
{
    public float speed = 10f;      // Velocidade da bala
    public int damage = 1;        // Dano causado pela bala
    private Vector2 direction;    // Direção da bala
    public float lifetime = 5f;   // Tempo máximo antes de destruir a bala

    void Start()
    {
        // Destroi a bala automaticamente após o tempo de vida útil
        Destroy(gameObject, lifetime);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized; // Define a direção como um vetor unitário
    }

    void Update()
    {
        // Move a bala na direção definida
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Obtém o script do inimigo antes de destruir a bala
            EnemyController enemy = collision.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Aplica dano ao inimigo
            }
        }

        Debug.Log("Atingiu algo! Bala será destruída.");
       
    }
}

