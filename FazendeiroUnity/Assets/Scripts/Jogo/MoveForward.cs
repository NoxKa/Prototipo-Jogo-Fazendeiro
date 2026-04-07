using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 20f;
    private GameObject player;
    private PlayerController playerScript; // Variavel do script
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScript.isPaused)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
