using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public AudioClip somColeta;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FirstPersonController player = other.GetComponent<FirstPersonController>();
            if (player != null)
            {
                player.HabilitarCorrida(); // Agora o player corre com Shift

                if (somColeta != null)
                {
                    AudioSource.PlayClipAtPoint(somColeta, transform.position);
                }

                Destroy(gameObject);
            }
        }
    }
}
