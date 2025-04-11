using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float novaVelocidade = 12f;
    public AudioClip somColeta;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FirstPersonController player = other.GetComponent<FirstPersonController>();
            if (player != null)
            {
                player.SetVelocidadePermanente(novaVelocidade);

                // Toca o som da coleta
                if (somColeta != null)
                {
                    AudioSource.PlayClipAtPoint(somColeta, transform.position);
                }

                Destroy(gameObject);
            }
        }
    }
}
