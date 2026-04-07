using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20f;
    private float spawnPositionZ = 20f;
    //private float startDelay = 2f;
    private float spawnInterval = 1.5f;
    private GameObject player;
    private PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnAnimal", startDelay, spawnInterval);
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
        StartCoroutine(SpawnAnimal());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isPaused)
        {
            spawnInterval = 0;
        }else if (!playerScript.isPaused)
        {
            spawnInterval = 1.5f;
        }
    }

    private IEnumerator SpawnAnimal()
    {
        // escolhe um animal aleatoriamente
        // animalPrefabs.Length retorna o tamanho do vetor
        // escolhe um posição x aleatoriamente
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (!playerScript.isPaused)
            {
                int animalIndex = Random.Range(0, animalPrefabs.Length);
                Vector3 randomPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);
                Instantiate(animalPrefabs[animalIndex], randomPosition,
                animalPrefabs[animalIndex].transform.rotation);
            }
        }
    }
    /*private IEnumerator GerarEntulhos()
    {
        float genY;
        int entulhosIndex;
        float genTime;
        while (true)
        {
            genTime = Random.Range(1, 8);
            yield return new WaitForSeconds(genTime);
            entulhosIndex = Random.Range(0, entulhosPrefabs.Length);
            genY = Random.Range(-genYrange, genYrange);
            Instantiate(entulhosPrefabs[entulhosIndex], new Vector2(genX, genY), entulhosPrefabs[entulhosIndex].transform.rotation);
        }
    }*/
}
