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



    #endregion
    

    void  Awake() 
    {
        speed = normalSpeed;
        enemyTransform = gameObject.transform;
        
    }

    void FixedUpdate() 
    {
        ProcMovment(Time.fixedDeltaTime);
        
    }



    void ProcMovment(float delTime)
    {
        enemyTransform.position += new Vector3(0f,-speed *delTime,0f);

    }
}
