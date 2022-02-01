using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    #region Vars

    [Header ("Movment Vars")]
    public float normalSpeed;
    private float speed;
    private Transform playerTrans;
    private Vector2 velocity;

    [Header ("Shooting Vars")]
    public float cooldown = 1f;
    public GameObject ammo;
    public GameObject leftAim;
    public GameObject rightAim;
    private bool canShoot = true;


    #endregion

    void Awake() 
    {
        //Get vars
        playerTrans = GetComponent<Transform>();
        speed = normalSpeed;
        
    }

    void Update()
    {
        ProcInput();

    }

    void FixedUpdate()
    {
        PorcMovment(Time.fixedDeltaTime);

    }

    void ProcInput()
    {
        //Player input
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        //Normlize vector
        velocity = new Vector2(inputX, inputY).normalized;


        if (Input.GetKey("space") && canShoot){
            canShoot = false;
            SpawnBullet();
            StartCoroutine(ShootCooldwon());
        }
    }

    void PorcMovment(float delTime)
    {
        //Calc movment
        playerTrans.position += new Vector3(velocity.x, velocity.y ,0f) * speed * delTime;

    }

    void SpawnBullet()
    {
        Instantiate(ammo,leftAim.transform.position, Quaternion.identity);
        Instantiate(ammo,rightAim.transform.position, Quaternion.identity);

    }

    IEnumerator ShootCooldwon()
    {
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
