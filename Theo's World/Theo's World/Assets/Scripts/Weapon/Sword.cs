using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : ItemBase, IWeapon
{
  public int AttackPower => 1;

  public float HoldDuration => 2;

  public bool HoldInteract => true;

  public bool MultipleUse => false;

  public bool IsInteractable => true;

  public bool IsEquipped => false;


  public void Attack()
  {
    //Implement
  }

  public override void Equip()
  {
    var c = GameObject.FindGameObjectWithTag("Player");
    if (c is not null)
    {
      Debug.Log(GameObject.FindGameObjectWithTag("Player"));
    }
    else
    {
      Debug.Log("Null");
    }
    Debug.Log(GameObject.FindGameObjectWithTag("Player"));
    transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
    transform.localPosition = Vector3.zero;
    IsEquipped = true;
  }
}
