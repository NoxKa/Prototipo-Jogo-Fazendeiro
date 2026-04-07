using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public int danoComida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Veado"))
        {
            var canvas = FindAnyObjectByType<CanvasScript>();
            var animalScript = other.gameObject.GetComponent<AnimalVidas>();
            animalScript.AtualizarVidaAnimal(danoComida);
            Destroy(gameObject);
        }
    }
}
