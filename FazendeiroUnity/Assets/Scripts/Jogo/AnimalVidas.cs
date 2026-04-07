using UnityEngine;

public class AnimalVidas : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    public bool isDropper;
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
            if (isDropper)
            {
                Drop();
            }
            Destroy(this.gameObject);
        }
    }
    public void AtualizarVidaAnimal(int dano)
    {
        vidaAtual -= dano;
    }
    public void Drop()
    {
        int dropChance = Random.Range(1, 5);
        int powerUpIndex = Random.Range(0, powerUpPrefabs.Length);
        if (dropChance >= 5)
        {
            print("Dropu"); // Problema aqui
            Instantiate(powerUpPrefabs[powerUpIndex], transform.position, powerUpPrefabs[powerUpIndex].transform.rotation);
        }
    }
}
