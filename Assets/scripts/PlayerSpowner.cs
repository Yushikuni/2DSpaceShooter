using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpowner : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;

    float respawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInstance == null)
        {
            respawnTimer -= Time.deltaTime;

            if(respawnTimer <= 0 )
            {
                SpawnPlayer();
            }
        }
    }

    void SpawnPlayer()
    {
        respawnTimer = 2f;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerInstance.name = "PlayerShip";
    }
}
