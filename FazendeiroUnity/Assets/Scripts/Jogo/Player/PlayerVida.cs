using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerVida : MonoBehaviour
{
    public int maxVida;
    private int vidaAtual;
    private GhostMode playerScript;
    private bool onShield = false;
    public GameObject shield;
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
            switch(powerUpScript.powerUpIndex)
            {
                case 1:
                print("entered");
                    if (vidaAtual < maxVida)
                    {
                        MudarVida(1);
                    }
                    break;
                case 2:
                    StartCoroutine(NovaBala());
                    break;
                case 3:
                    StartCoroutine(StartShield());
                    break;
                    

            }
            Destroy(other.gameObject);
        }
    }
    private void MudarVida(int mod)
    {
        if (onShield && mod < 0)
        {
            mod = 0;
        }
        vidaAtual += mod;
        var canvas = FindAnyObjectByType<CanvasScript>();
        canvas.AtualizarVida(vidaAtual);
        canvas.AtualizarPontos(1);
    }
    private IEnumerator NovaBala()
    {
        var playerController = GetComponent<PlayerController>();
        if (playerController.projectileIndex == 0)
        {
            playerController.projectileIndex = 1;
            yield return new WaitForSeconds(10);
            playerController.projectileIndex = 0;
        }
    }
    private IEnumerator StartShield()
    {
        if (!onShield)
        {
            shield.SetActive(true);
            onShield = true;
            yield return new WaitForSeconds(15);
            onShield = false;
            shield.SetActive(false);
        }
    }
}
