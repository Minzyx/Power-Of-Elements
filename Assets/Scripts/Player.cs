using UnityEngine;
using UnityEngine.SceneManagement;  // Adiciona essa linha para manipular a cena

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float maxVidaPlayer;
    public float vidaPlayer;
    public PlayerHealthUI healthUI;

    void Start()
    {
        vidaPlayer = maxVidaPlayer;

        if (healthUI != null)
        {
            healthUI.SetHealth((int)vidaPlayer);
        }
    }

    void Update()
    {
        // Pode adicionar outras lógicas do jogo aqui
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        vidaPlayer--;

        if (healthUI != null)
        {
            healthUI.SetHealth((int)vidaPlayer);
        }

        if (vidaPlayer <= 0)
        {
            // Quando a vida acabar, reinicia a cena
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
