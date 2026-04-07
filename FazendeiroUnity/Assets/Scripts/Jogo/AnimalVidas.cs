using UnityEngine;

public class AnimalVidas : MonoBehaviour
{
    public int vidaMax;
    private int vidaAtual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaAtual <= 0)
        {
            var canvas = FindAnyObjectByType<CanvasScript>();
            canvas.AtualizarPontos(vidaMax);
            Destroy(this.gameObject);
        }
    }
    public void AtualizarVidaAnimal(int dano)
    {
        vidaAtual -= dano;
    }
}
