using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.InputSystem.DualShock;

public class Ps4Controller : MonoBehaviour
{
  [SerializeField] private GameObject Player = null;
  [SerializeField] private PlayerController PlayerController = null;
  private DualShock4GamepadHID PS4Controller;
  [SerializeField] private float SprintModifier = 1.5f;
  // Start is called before the first frame update
  void Start()
  {
    foreach (Gamepad gp in Gamepad.all)
    {
      if (gp.GetType() == typeof(DualShock4GamepadHID))
      {
        PS4Controller = (DualShock4GamepadHID)gp;
      }
      else//Handle other input devices
      {
        Debug.Log("Found other type of controller");
      }
      Debug.Log(gp);
    }
    Physics.gravity = new Vector3(0, -10, 0);
  }

  // Update is called once per frame
  void Update()
  {
    CheckControllerInputs();
  }

  private void CheckControllerInputs()
  {
    if (Player is not null && PlayerController is not null)
    {
      if (PS4Controller is not null)
      {
        //Pausae
        if (PS4Controller.optionsButton.wasPressedThisFrame)
        {
          PauseController.PauseGame();
        }
        if (!PauseController.isGamePaused)
        {
          //Sprinting
          if (PlayerController.isGrounded == true)
          {
            PlayerController.isSprinting = IsSprinting();
          }
          PlayerController.isMoving = IsAnyLeftStickDirectionPressed();
          if (PlayerController.isMoving)
          {
            //Movements N E S W
            Move();
          }
          //jumping
          if (PlayerController.isGrounded == true)
          {
            if (PS4Controller.crossButton.isPressed)
            {
              Jump();
            }
          }
          else
          {
            Fall();
          }
        }
      }
    }
    else
    {
      Debug.Log("Player is null or playercontroller is null.");
    }
  }

  private bool IsAnyLeftStickDirectionPressed() => PS4Controller.leftStick.ReadValue() != Vector2.zero;

  private bool IsSprinting() => PS4Controller.leftStickButton.isPressed;

  private void Move()
  {
    Vector2 movementAmount = PS4Controller.leftStick.ReadValue();
    float sprintFactor = 1.0f;
    if (PlayerController.isSprinting)
    {
      sprintFactor = SprintModifier;
    }
    Player.transform.position += new Vector3(movementAmount.x, 0, movementAmount.y) * PlayerController.Speed * Time.deltaTime * sprintFactor;
    Player.transform.LookAt(Player.transform.position + new Vector3(movementAmount.x, 0, movementAmount.y));
  }
  private void Fall()
  {
    Rigidbody rb = Player.GetComponent<Rigidbody>();
    if (rb.velocity.y < 0)
    {
      rb.velocity += Vector3.up * Physics.gravity.y * (PlayerController.FallFactor - 1) * Time.deltaTime;
      Debug.Log("Falling");
    }
  }
  private void Jump()
  {
    Rigidbody rb = Player.GetComponent<Rigidbody>();
    if (PlayerController.isGrounded)
    {
      float jumpVelocity = Mathf.Sqrt(2 * PlayerController.JumpFactor * Mathf.Abs(Physics.gravity.y));
      rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
      PlayerController.isGrounded = false;
    }
    if (rb.velocity.y < 0)
    {
      rb.velocity += Vector3.up * Physics.gravity.y * (PlayerController.FallFactor - 1) * Time.deltaTime;
      Debug.Log("Falling");
    }
  }
}

