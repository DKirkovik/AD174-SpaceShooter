using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    #region Vars
    [Header ("Move Vars")]

    public float normalSpeed;
    private float speed;
    
    [Header ("Bullet Stat")]

    public float lifeTime = 2f;
    public float waitTime = 0.15f;

    #endregion

    [Header ("Bullet Audio")]

    private AudioSource bulletAudio;


    void Awake()
    {
        //Set Vars
        speed = normalSpeed;
        bulletAudio = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {
        //Proc movment
        this.transform.position += new Vector3(0f, speed *Time.fixedDeltaTime, 0f);

        Destroy(gameObject, lifeTime);

    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        //Destory on Collision
        if(other.gameObject.tag == "Enemy"){
            //Destroy Enemy
            Destroy(other.gameObject);
            //Play Audio
            bulletAudio.PlayOneShot(bulletAudio.clip);
            //Destroy self after waitTime
            Destroy(this.gameObject,waitTime);
        }
        
    }
}
