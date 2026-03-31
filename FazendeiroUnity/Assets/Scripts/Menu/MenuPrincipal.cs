using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string fase1;
    [SerializeField] private GameObject painelMenuPrincipal;
    [SerializeField] private GameObject painelOptions;
    [SerializeField] private GameObject painelSair;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Jogar()
    {
        SceneManager.LoadScene(fase1);
    }
    public void OnOptions()
    {
        painelMenuPrincipal.SetActive(false);
        painelOptions.SetActive(true);
    }
    public void OffOptions()
    {
        painelOptions.SetActive(false);
        painelMenuPrincipal.SetActive(true);
    }
    public void OnSair()
    {
        painelMenuPrincipal.SetActive(false);
        painelSair.SetActive(true);
    }
    public void OffSair()
    {
        painelSair.SetActive(false);
        painelMenuPrincipal.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
        print("Saiu");
    }
}
