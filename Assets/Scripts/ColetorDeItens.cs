using UnityEngine;

public class ColetorDeItens : MonoBehaviour
{
    public int itensColetados = 0;
    public AudioClip somDeColeta; // <-- som que será tocado
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coletavel"))
        {
            itensColetados++;
            if (somDeColeta != null)
                audioSource.PlayOneShot(somDeColeta);

            Destroy(other.gameObject);
            Debug.Log("Item coletado! Total: " + itensColetados);
        }
    }
}

