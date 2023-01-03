using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] public float Speed = 5f;
  [SerializeField] public float JumpFactor = 50f;
  public bool isGrounded = true;
  public bool isHurt = false;
  public bool isSprinting = false;
  public bool isMoving = false;
  private int damage = 2;

  public int Damage
  {
    set { damage = value; }
    get { return damage; }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Floor"))
    {
      Debug.Log("Collision with floor.");
      isGrounded = true;
    }
    if(collision.collider.gameObject.tag == "Enemy")
    {
      isHurt = true;
    }
  }
  private void OnCollisionExit(Collision collision)
  {
    if (collision.collider.gameObject.tag == "Enemy")
    {
      Debug.Log("Leaving enermy");
      isHurt = false;
    }
  }
}
