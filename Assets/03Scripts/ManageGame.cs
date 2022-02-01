using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageGame : MonoBehaviour
{
    //Making this persistent
    public static ManageGame instance;

    #region Vars
    [Header ("Score Vars")]
    public float score = 0f;
    public Text scoreText;



    #endregion

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        UpdateUI();
    }


    public void UpdateScore(float points)
    {
        score += points;
        UpdateUI();
    }

    public void UpdateUI()
    {
        scoreText.text = score.ToString();
    }
}
