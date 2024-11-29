using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public Image[] lifeImages; // Array para armazenar as imagens de vidas
    public int currentLives = 5; // Número inicial de vidas

    void Start()
    {
        UpdateLivesUI(); // Atualizar a interface inicial
    }

    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--; // Reduz uma vida
            UpdateLivesUI(); // Atualiza a interface
        }

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    public void GainLife()
    {
        if (currentLives < lifeImages.Length)
        {
            currentLives++; // Adiciona uma vida
            UpdateLivesUI();
        }
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (i < currentLives)
            {
                lifeImages[i].enabled = true; // Mostra a imagem se ainda houver vida
            }
            else
            {
                lifeImages[i].enabled = false; // Esconde a imagem se não houver mais vida
            }
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        // Aqui você pode adicionar lógica para reiniciar o jogo ou mostrar uma tela de fim de jogo.
    }
}
