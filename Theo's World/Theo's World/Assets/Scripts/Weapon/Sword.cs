using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : ItemBase, IWeapon
{
  private bool isEquipped = false;

  public int AttackPower => 1;

  public float HoldDuration => 2;

  public bool HoldInteract => true;

  public bool MultipleUse => false;

  public bool IsInteractable => true;

  public bool IsEquipped
  {
    get => isEquipped;
    set => isEquipped = value;
  }

  public void Attack()
  {
    //Implement
  }

  public override void Equip()
  {
    var player = GameObject.FindGameObjectWithTag("Player");

    // Get the colliders for the player and sword
    Collider playerCollider = player.GetComponent<Collider>();
    Collider swordCollider = GetComponent<Collider>();

    // Ignore collisions between the player and sword colliders
    Physics.IgnoreCollision(playerCollider, swordCollider);
    transform.SetParent(player.transform);
    // Set the local position of the object relative to the player
    transform.localPosition = Vector3.zero;
    transform.position = Vector3.zero;
    Debug.Log(transform.position);
    new WaitForSeconds(3.0f);
    IsEquipped = true;
  }
}
