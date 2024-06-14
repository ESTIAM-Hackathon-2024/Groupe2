using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90F;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }




        GameManager.inst.IncrementScore();

        if (GameManager.inst.score > 100)
        {
            Playermove playerMove = other.gameObject.GetComponent<Playermove>();
            if (playerMove != null)
            {
                playerMove.ChangeScene();
            }
        }

        Destroy(gameObject);
    }


    void Start()
    {

    }

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}