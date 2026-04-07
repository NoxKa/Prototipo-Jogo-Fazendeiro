using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVida : MonoBehaviour
{
    public int maxVida;
    private int vidaAtual;
    private GhostMode playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtual = maxVida;
        playerScript = GetComponentInChildren<GhostMode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaAtual <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Veado") && !playerScript.isGhost)
        {
            var canvas = FindAnyObjectByType<CanvasScript>();
            Destroy(other.gameObject);
            vidaAtual--;
            canvas.AtualizarVida(vidaAtual);
            canvas.AtualizarPontos(1);
        }
    }
}
