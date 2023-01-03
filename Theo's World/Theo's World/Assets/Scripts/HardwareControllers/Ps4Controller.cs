using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class Ps4Controller : MonoBehaviour
{
  [SerializeField] private GameObject Player = null;
  [SerializeField] private PlayerController PlayerController = null;
  // Start is called before the first frame update
  void Start()
  {
    foreach (Gamepad gp in Gamepad.all)
    {
      Debug.Log(gp);
    }
    Physics.gravity = new Vector3(0, -10, 0);
  }

  // Update is called once per frame
  void Update()
  {
    if (Player is not null && PlayerController is not null)
    {
      if (Gamepad.all.Count > 0)
      {
        float sprintModifier = 1;
        //Sprinting
        if (PlayerController.isGrounded == true)
        {
          if (Gamepad.all.First().leftStickButton.isPressed)
          {
            sprintModifier = 1.5f;
            PlayerController.isSprinting = true;
            Debug.Log("Sprinting");
          }
          else
          {
            PlayerController.isSprinting = false;
            Debug.Log("Stopped sprinting");
          }
        }
        if (Gamepad.all.First().leftStick.left.isPressed || Gamepad.all.First().leftStick.right.isPressed ||
          Gamepad.all.First().leftStick.up.isPressed || Gamepad.all.First().leftStick.down.isPressed)
        {
          PlayerController.isMoving = true;
        }
        else
        {
          PlayerController.isMoving = false;
        }
        //Movements N E S W
        if (Gamepad.all.First().leftStick.left.isPressed)
        {
          Player.transform.position += (Vector3.left * Time.deltaTime * PlayerController.Speed) * sprintModifier;
        }
        if (Gamepad.all.First().leftStick.right.isPressed)
        {
          Player.transform.position += (Vector3.right * Time.deltaTime * PlayerController.Speed) * sprintModifier;
        }
        if (Gamepad.all.First().leftStick.up.isPressed)
        {
          Player.transform.position += (Vector3.forward * Time.deltaTime * PlayerController.Speed) * sprintModifier;
        }
        if (Gamepad.all.First().leftStick.down.isPressed)
        {
          Player.transform.position += (Vector3.back * Time.deltaTime * PlayerController.Speed) * sprintModifier;
        }
        //jumping
        if (PlayerController.isGrounded == true)
        {
          if (Gamepad.all.First().crossButton.isPressed)
          {
            Player.transform.position += Vector3.up * Time.deltaTime * PlayerController.JumpFactor;
            PlayerController.isGrounded = false;
          }
        }
      }
    }
  }
}
