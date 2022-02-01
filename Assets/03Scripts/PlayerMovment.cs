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
    public float shootCooldown = 1f;
    public float ammoCooldown = 0.2f;
    public GameObject ammo;
    public GameObject leftAim;
    public GameObject rightAim;
    public GameObject leftAmmoParent;
    public GameObject rightAmmoParent;
    public GameObject fireSound;
    private bool canShoot = true;
    private AudioSource ammAudioSource;


    #endregion

    void Awake() 
    {
        //Get vars
        playerTrans = GetComponent<Transform>();
        speed = normalSpeed;
        ammAudioSource = fireSound.GetComponent<AudioSource>();
        
    }

    void Update()
    {
        //Process input
        ProcInput();

    }

    void FixedUpdate()
    {
        //Process movment
        PorcMovment(Time.fixedDeltaTime);

    }

    void ProcInput()
    {
        //Player input
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        //Normlize vector
        velocity = new Vector2(inputX, inputY).normalized;

        //Shooting input
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
        //Spawning bullet
        ammAudioSource.PlayOneShot(ammAudioSource.clip);
        //Left
        GameObject leftAmmo = Instantiate(ammo,leftAim.transform.position, Quaternion.identity);
        leftAmmo.transform.parent = leftAmmoParent.transform; //Set parent
        //Coroutine for right bullet
        StartCoroutine(BulletCooldwon());


    }

    IEnumerator ShootCooldwon()
    {
        //Cooldown timer
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
    IEnumerator BulletCooldwon()
    {
        //Cooldown timer
        yield return new WaitForSeconds(ammoCooldown);

        //Spawning Right bullet
        ammAudioSource.PlayOneShot(ammAudioSource.clip);
        GameObject rightAmmo = Instantiate(ammo, rightAim.transform.position, Quaternion.identity);
        rightAmmo.transform.parent = rightAmmoParent.transform; //Set parent
    }
}
