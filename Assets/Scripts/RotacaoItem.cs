using UnityEngine;

public class RotacaoItem : MonoBehaviour
{
    public float velocidadeRotacao = 100f;
    public float altura = 0.5f;
    public float velocidadeFlutuacao = 2f;

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Rotação
        transform.Rotate(0, velocidadeRotacao * Time.deltaTime, 0);

        // Flutuação
        float novaY = posicaoInicial.y + Mathf.Sin(Time.time * velocidadeFlutuacao) * altura;
        transform.position = new Vector3(posicaoInicial.x, novaY, posicaoInicial.z);
    }
}
