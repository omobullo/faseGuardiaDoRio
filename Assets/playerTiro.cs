using UnityEngine;


public class playerTiro : MonoBehaviour
{
    [SerializeField] // Garante que o campo apareça no Inspector
    private GameObject bulletPrefab;
    

    public Transform firePoint; // Ponto de origem do disparo
    private bool facingRight = true;


    void Update()
    {
        // Detecta entrada para disparar
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }


        // Atualiza a direção com base no movimento
        if (Input.GetAxisRaw("Horizontal") > 0)
            facingRight = true;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            facingRight = false;


        // Opcional: Vira o sprite
        GetComponent<SpriteRenderer>().flipX = !facingRight;
    }


void Shoot()
{
    Debug.Log("Tentando disparar...");

    if (bulletPrefab == null)
    {
        Debug.LogError("O prefab da bala ainda não foi atribuído no Inspector!");
        return;
    }

    // Instancia a bala
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

if (bullet != null)
{
    Bullet bulletScript = bullet.GetComponent<Bullet>();
    if (bulletScript != null)
    {
        Vector2 bulletDirection = facingRight ? Vector2.right : Vector2.left;
        bulletScript.SetDirection(bulletDirection); // Configura a direção da bala
        Debug.Log("Bala criada e direção definida.");
    }
    else
    {
        Debug.LogError("Script 'Bullet' não encontrado no prefab!");
    }
}

}
}
