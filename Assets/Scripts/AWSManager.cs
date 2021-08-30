using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amazon;
using Amazon.S3;

public class AWSManager : MonoBehaviour
{
    private static AWSManager _instance;
    public static AWSManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AWSManager is null!");
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        UnityInitializer.AttachToGameObject(this.gameObject);
        //initialize the http client
        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;
        
    }
  
}
