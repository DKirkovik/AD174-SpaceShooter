using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovment : MonoBehaviour
{
    #region Vars

    [Header("Movment Vars")]

    public float normalSpeed;
    private Transform enemyTransform;
    private float speed;

    [Header ("Enemy Stats")]

    public float lifeTime = 6f;
    public float waitTime = 2f;


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

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player"){
            StartCoroutine(RestartCooldown());

        }
        
    }


    IEnumerator RestartCooldown()
    {
        //Restart timer
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
