using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoots : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    Transform player;

    public float fireTimer = 0.1f;
    float cooldownTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("PlayerShip");
            if(go != null)
            {
                player = go.transform;
            }
        }

        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0 && player != null && Vector3.Distance (transform.position, player.position) < 4)
        {
           Debug.Log("kabóóm! say ENEMY");
           cooldownTimer = fireTimer;

           Vector3 offset = transform.rotation * bulletOffset;

           GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, transform.position, transform.rotation);
           bulletGO.layer = gameObject.layer;
        }
    }
}
