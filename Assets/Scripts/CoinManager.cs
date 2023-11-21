using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public Transform[] coinSpawnPositions;
    public GameObject coin;
    
    public float time = 0;




    // Start is called before the first frame update
    void Start()
    {
        GenerateCoin();
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time > 6 && GameManager.instance.timer > 0)
        {
            GenerateCoin();
            time = 0;
        }
    }

    void GenerateCoin()
    {
        Transform spawnPoint = coinSpawnPositions[Random.Range(0, coinSpawnPositions.Length)];

        Instantiate(coin, spawnPoint);
    }
}
