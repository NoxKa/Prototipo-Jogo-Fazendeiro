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
        MudarVida(0);
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
            Destroy(other.gameObject);
            MudarVida(-1);
        }else if (other.CompareTag("PowerUp"))
        {
            print("founded");
            PowerUp powerUpScript = other.gameObject.GetComponent<PowerUp>();
            PowerUp PowerUpPlayercript = GetComponent<PowerUp>();
            switch(powerUpScript.powerUpIndex)
            {
                case 1:
                print("entered");
                    if (vidaAtual < maxVida)
                    {
                        MudarVida(1);
                    }
                    break;
            }
            Destroy(other.gameObject);
        }
    }
    private void MudarVida(int mod)
    {
        vidaAtual += mod;
        var canvas = FindAnyObjectByType<CanvasScript>();
        canvas.AtualizarVida(vidaAtual);
        canvas.AtualizarPontos(1);
    }
}
