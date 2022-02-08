using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{

    #region Vars
    [Header ("Score Vars")]
    public float score = 0f;
    public Text scoreText;

    [Header ("Dont Destory")]
    public GameObject playerSoundObj;
    public GameObject scoreGameObj;

    [Header ("Death Screen")]

    public float waitTime = 2f;



    #endregion

    void Awake()
    {
        //Dont destory this game obj
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        //Check if score obj isnt null
        
        if (scoreText != null){
            Debug.Log("Not null");
            UpdateUI();

        }
        else{
            //Set score obj if its null
            scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
            
        }
        
    }


    public void UpdateScore(float points)
    {
        //Update score
        score += points;
        UpdateUI();
    }

    public void UpdateUI()
    {
        //Update UI and check if score obj is not null
        if(scoreText !=null){
            scoreText.text = score.ToString();
        }
        else{
            Debug.Log("Null");
            scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        }
    }
    public void DeathSceneChange()
    {
        //Set score back to zero and start scene change
        score = 0f;
        StartCoroutine(RestartCooldown());

    }


    IEnumerator RestartCooldown()
    {
        //Restart timer
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
}
