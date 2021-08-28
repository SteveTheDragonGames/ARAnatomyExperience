using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalloutLabel : MonoBehaviour
{
    public LineRenderer line;
    public GameObject targetObj;
    public Image label;
    public int currentAnim;
    
    void Start()
    {
        line.startWidth = 0.01f;
        line.endWidth = 0.01f;
        line.enabled = false;
        label.gameObject.SetActive(false);
    }

    void Update()
    {
        currentAnim = UIManager.Instance.currentAnim;

        if (UIManager.Instance.currentAnim == 1)
        {
            line.SetPosition(0, label.transform.position);
            line.SetPosition(1, targetObj.transform.position);
            
            line.enabled = true;
            label.gameObject.SetActive(true);
        }
        else
        {
            line.enabled = false;
            label.gameObject.SetActive(false);
            
        }
        
        
    }
}
