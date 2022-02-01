using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Vars

    [Header ("Spawn Vars")]
    public GameObject enemyPref;
    public GameObject spawnParent;
    public float spawnCooldown = 1f;
    private Transform spawnPoint;
    private bool canSpawn;

    #endregion


    void Start()
    {
        //Set Vars
        canSpawn = true;
        spawnPoint = gameObject.transform;
    }


    void FixedUpdate() 
    {
        //Spawning enemies
        if(canSpawn){
            canSpawn = false;
            SpawnEnemies();
        }
        
    }

    void SpawnEnemies()
    {
        //Instantiating
        GameObject spawnedEnemy = Instantiate(enemyPref,spawnPoint.position, enemyPref.transform.rotation);
        spawnedEnemy.transform.parent = spawnParent.transform;
        //Starting Coroutine
        StartCoroutine(SpawnTimer());

    }




    IEnumerator SpawnTimer()
    {
        //Cooldown timer
        yield return new WaitForSeconds(spawnCooldown);
        canSpawn = true;
    }
    
}
