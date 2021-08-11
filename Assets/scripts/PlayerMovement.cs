using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerHeatlh = 10;
    public int playerShild = 10;
    

    public float maxSpeed = 2.5f;
    public float rotSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rotovani s lodickou jen tak pro efekt :D
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //pohyb s lodickou
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;
        transform.position = pos;

        if (playerShild <= 0)
        {
            playerHeatlh--;
            if(playerHeatlh <= 0)
            {
                Die();
            }          
        }

    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!!! PLAYER MOVEMENTS -_-");
        playerShild--;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
