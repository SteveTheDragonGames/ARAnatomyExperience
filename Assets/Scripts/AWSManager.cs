using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amazon;
using Amazon.S3;
using Amazon.S3.Util;
using Amazon.CognitoIdentity;
using Amazon.S3.Model;
using Amazon.Runtime;


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

    public string S3Region = RegionEndpoint.USWest1.SystemName;
    private RegionEndpoint _S3Region
    {
        get{return RegionEndpoint.GetBySystemName(S3Region);}
    }   

    private AmazonS3Client _s3Client;
    public AmazonS3Client S3Client
    {
        get
        {
            if(_s3Client == null)
            {
                _s3Client = new AmazonS3Client(
                    new CognitoAWSCredentials(Keys.AMAZON_KEY, //Identity pool ID
                    RegionEndpoint.USWest1 //Region
                    ), _S3Region);
            }

            return _s3Client;
        }
    }

    void Awake()
    {
         
        _instance = this;
        UnityInitializer.AttachToGameObject(this.gameObject);
        //initialize the http client
        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;       

    }

    void Start()
    {
        Debug.Log("S3Client: " + S3Client);
        
        //Create a constructor
        var request = new ListObjectsRequest()
        {
            BucketName = "sdaranatomy"
        };

        Debug.Log(request);

        S3Client.ListObjectsAsync(request, (responseObject) =>
        {
            if (responseObject.Exception == null)
            {
                responseObject.Response.S3Objects.ForEach((obj) => 
                {
                    Debug.Log("Object: "+obj.Key);
                });
            }
            else
            {
                Debug.Log("Response Object: "+responseObject.Exception);
            }
        });
    }
  
}
