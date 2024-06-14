using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Playermove playerMovement;
    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<Playermove>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") {
            playerMovement.Die();
        }
    }
    void Update()
    {
        
    }
}
