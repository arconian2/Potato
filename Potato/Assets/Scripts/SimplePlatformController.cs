using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformController : MonoBehaviour {
     public int playerSpeed = 25;
     private bool facingRight = true;
     public int playerJumpPower = 50;
     private float moveX;
     private float moveY;

     //update called once per frame
     void Update()
     {
          PlayerMove();
     }

     void PlayerMove() {
          // Controls
          moveX = Input.GetAxis("Horizontal");

          if (Input.GetButton("Jump"))
               Jump();

          if (moveX > 0.0f && !facingRight)
               flip();

          else if (moveX < 0.0f && facingRight)
               flip();


          gameObject.GetComponent<Rigidbody2D>().velocity
               = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
     }

     void Jump()
     {
          GetComponent<Rigidbody2D>().AddForce(Vector2.up*playerJumpPower);
     }



     void flip()
     {
          facingRight = !facingRight;
          Vector2 localScale = gameObject.transform.localScale;
          localScale.x *= -1;
          transform.localScale = localScale;
     }
}
