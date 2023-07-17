using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
  [TextArea]
  public string Description;
  public string ItemName;
  public Sprite ItemIcon;
  
  public virtual void Use()
  {
    //Implement item behavior
  }

  public abstract void Equip();
}
