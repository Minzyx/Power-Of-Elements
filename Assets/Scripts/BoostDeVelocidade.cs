using UnityEngine;

public class BoostDeVelocidade : MonoBehaviour
{
    public float novaVelocidade = 12f;
    public float duracao = 5f;
    public AudioClip somDeBoost;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo colidiu com o item: " + other.name);

        FirstPersonController player = other.GetComponent<FirstPersonController>();

        if (player != null)
        {
            Debug.Log("Player detectado! Ativando boost...");

            player.AtivarBoostVelocidade(novaVelocidade, duracao);

            if (somDeBoost != null)
            {
                AudioSource.PlayClipAtPoint(somDeBoost, transform.position);
            }

            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Mas não era o player 😢");
        }
    }
}
