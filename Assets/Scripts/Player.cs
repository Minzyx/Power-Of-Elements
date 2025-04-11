using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float maxVidaPlayer;
    public float vidaPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaPlayer = maxVidaPlayer;

    }

    // Update is called once per frame
    void Update()
    {
        
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
    }


}
