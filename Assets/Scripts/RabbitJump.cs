using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
  
public class RabbitJump : MonoBehaviour  
{  
    public float jumpForce = 10f; // 跳跃力量  
    public Vector2 jumpDirection = new Vector2(0f, 1f); // 跳跃方向，向上  
  
    private Rigidbody2D rb;  
    private bool isGrounded = false; // 标记兔子是否接地  
  
    void Start()  
    {  
        rb = GetComponent<Rigidbody2D>();  
    }  
  
    void Update()  
    {  
        // 检查跳跃输入  
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))  
        {  
            // 如果兔子接地，则允许跳跃  
            if (isGrounded)  
            {  
                Jump();  
            }  
        }  
    }  
  
    void OnCollisionStay2D(Collision2D collision)  
    {  
        // 检查碰撞体是否具有GroundTag标签  
        if (collision.gameObject.CompareTag("GroundTag"))  
        {  
            isGrounded = true; // 兔子接地  
        }  
        else  
        {  
            // 注意：这里我们不需要显式地将isGrounded设置为false，  
            // 因为当兔子不再与带有GroundTag的碰撞体接触时，  
            // isGrounded将保持其上一个值（在大多数情况下为false，除非我们刚刚设置了true）。  
            // 但是，为了清晰起见，你可以在这里添加一行代码来重置isGrounded，  
            // 尽管这不是必需的。  
            // isGrounded = false; // 兔子不接地（这行代码实际上是多余的）  
        }  
  
        // 注意：OnCollisionStay2D会在每一帧都调用，只要兔子与碰撞体接触。  
        // 因此，isGrounded会被频繁地设置为true（如果兔子在地面上）。  
        // 这意味着你不需要担心兔子在离开地面的瞬间再次触发接地，  
        // 因为只要兔子还在地面上，isGrounded就会保持为true。  
    }  
  
    void Jump()  
    {  
        // 跳跃逻辑  
        rb.velocity = Vector2.zero; // 清除当前速度（可选，取决于你的游戏逻辑）  
        rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse); // 添加跳跃力量  
  
        // 注意：我们不需要在这里设置isJumping变量，  
        // 因为我们只需要在兔子接地时允许跳跃。  
        // isJumping的用途通常是为了防止在空中时再次跳跃，  
        // 但在这个例子中，我们通过检查isGrounded来实现这一点。  
    }  
}