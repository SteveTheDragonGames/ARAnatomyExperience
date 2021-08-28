using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UIManager is null");
            }
            return _instance;
        }

    }

    public Animator anim;
    public int currentAnim = 0;

    void Awake()
    {
        _instance = this;
    }
    
    public void Next()
    {
        
        if (currentAnim == 2)
        {
            //do nothing
        }
        else
        {
            currentAnim ++;
        }
            
        anim.SetInteger("NextAnim", currentAnim);
    }

    public void Previous()
    {
        
        if (currentAnim == 0)
        {
            //do nothing 
        }
        else
        {
            currentAnim --;
        }           

        anim.SetInteger("NextAnim", currentAnim);    

    }
}
