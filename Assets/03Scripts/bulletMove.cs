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

    #endregion


    void Start()
    {
        speed = normalSpeed;

    }

    void FixedUpdate()
    {
        this.transform.position += new Vector3(0f, speed *Time.fixedDeltaTime, 0f);

        Destroy(gameObject, lifeTime);

    }
}
