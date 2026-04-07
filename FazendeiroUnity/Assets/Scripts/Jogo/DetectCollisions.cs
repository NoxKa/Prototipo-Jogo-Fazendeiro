using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
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
            Destroy(gameObject);
            Destroy(other.gameObject);
            canvas.AtualizarPontos(1);
        }
    }
}
