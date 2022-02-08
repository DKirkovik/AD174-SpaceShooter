using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        //Check if player null
        if (player == null){
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        //Destroy player on enemy enter
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(player);
        }
        
    }
}
