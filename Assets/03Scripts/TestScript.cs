using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    #region Vars

    [Header ("Test Vars")]
    public Vector3 testVector;
    private Transform objTransform;


    #endregion


    void Start() 
    {
        objTransform = GetComponent<Transform>();
        objTransform.position = testVector;
        
    }
}
