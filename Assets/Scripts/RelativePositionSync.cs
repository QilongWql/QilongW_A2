using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
  
public class RelativePositionSync : MonoBehaviour  
{  
    public Transform parentObject; // 船，作为父对象  
    private Vector3 relativePosition; // 兔子相对于船的位置  
  
    void Start()  
    {  
        // 在Start中记录兔子相对于船的位置  
        if (parentObject != null)  
        {  
            relativePosition = transform.position - parentObject.position;  
        }  
    }  
  
    void Update()  
    {  
        // 在每一帧中更新兔子的位置，以保持其相对于船的位置不变  
        if (parentObject != null)  
        {  
            transform.position = parentObject.position + relativePosition;  
        }  
    }  
}