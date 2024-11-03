using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
  
public class RabbitController : MonoBehaviour  
{  
    public float jumpForce = 10f; // 跳跃力量  
    public string GroundTag = "Ground"; // 用于检测地面的标签名称  
  
    private Rigidbody2D rb;  
    private bool canJump = true; // 标记兔子是否可以被跳跃  
  
    void Start()  
    {  
        rb = GetComponent<Rigidbody2D>();  
    }  
  
    void OnMouseDown()  
    {  
        // 检查是否点击了兔子，并且是否允许跳跃  
        if (canJump)  
        {  
            Jump();  
        }  
    }  
  
    void OnCollisionEnter2D(Collision2D collision)  
    {  
        // 检查碰撞体的标签是否与我们指定的地面标签相匹配  
        if (collision.gameObject.CompareTag(GroundTag))  
        {  
            // 兔子落地时允许跳跃  
            canJump = true;  
        }  
    }  
  
    void Jump()  
    {  
        // 设置不允许跳跃，直到下次落地  
        canJump = false;  
  
        // 添加跳跃力量  
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);  
        // 注意：这里直接设置了速度，如果你想要更物理的跳跃，可以使用 AddForce。  
    }  
}