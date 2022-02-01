using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    #region Vars

    [Header("Movment Vars")]

    public float normalSpeed;
    private Transform enemyTransform;
    private float speed;

    [Header ("Enemy Stats")]

    public float lifeTime = 6f;


    #endregion
    

    void  Awake() 
    {
        //Set Vars
        speed = normalSpeed;
        enemyTransform = gameObject.transform;
        
    }

    void Start() 
    {
        Destroy(this.gameObject,lifeTime);
        
    }

    void FixedUpdate() 
    {
        //Movment
        ProcMovment(Time.fixedDeltaTime);
        
    }



    void ProcMovment(float delTime)
    {
        //Proc movment
        enemyTransform.position += new Vector3(0f,-speed *delTime,0f);

    }
}
