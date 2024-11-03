using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
  
public class BoatMovement : MonoBehaviour  
{  
    public float speed = 5.0f; // 小船移动速度  
    private bool isMoving = false; // 是否正在移动  
  
    // Update is called once per frame  
    void Update()  
    {  
        // 检查是否点击了小船  
        if (Input.GetMouseButtonDown(0))  
        {  
            Vector3 mousePos = Input.mousePosition;  
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);  
            Vector2 worldPos2D = new Vector2(worldPos.x, worldPos.y);  
  
            Collider2D hit = Physics2D.OverlapPoint(worldPos2D);  
  
            if (hit != null && hit.gameObject == gameObject)  
            {  
                isMoving = true;  
            }  
        }  
  
        // 如果小船正在移动，则更新其位置  
        if (isMoving)  
        {  
            transform.Translate(Vector3.right * speed * Time.deltaTime);  
        }  
    }  
}