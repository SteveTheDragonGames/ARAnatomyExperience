using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Animator anim;
    public int currentAnim = 0;
    
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
