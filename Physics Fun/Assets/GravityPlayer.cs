using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityTemplateProjects
{
  public class GravityPlayer : MonoBehaviour
  {
    public CharacterController controller;

    public float gravity = -9.81f;
    Vector3 velocityDueToGravity;
    Vector3 move;
    public float jumpHeight = 3.0f;
    public SimpleCameraController parent;

    public void Jump()
    {
      velocityDueToGravity.y = Mathf.Sqrt(-2f * gravity * jumpHeight);

    }

    // Update is called once per frame
    void Update()
    {
      // Add movement due to gravity
      if (velocityDueToGravity.y < 0 && parent.isGrounded) {
        velocityDueToGravity.y = -2f;
      }
      velocityDueToGravity = transform.up * (velocityDueToGravity.y + gravity * Time.deltaTime);
      move = velocityDueToGravity * Time.deltaTime;
      controller.Move(move);

      // // vertical movement keys
      // Vector3 yChange = transform.up * 0;
      // if (Input.GetKey(KeyCode.Q))
      // {
      //     yChange += Vector3.down;
      //     velocityDueToGravity = transform.up * 0;
      // }
      // if (Input.GetKey(KeyCode.E))
      // {
      //     yChange += Vector3.up;
      //     velocityDueToGravity = transform.up * 0;
      // }
      // controller.Move(yChange * boost * Time.deltaTime);
    }
  }
}
