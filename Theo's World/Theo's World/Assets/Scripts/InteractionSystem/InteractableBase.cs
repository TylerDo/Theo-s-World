using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour, IInteractable
{
  [Header("Interactable Settings")]
  private float holdDuration = 1f;
  [Space]
  private bool holdInteract = true;
  private bool multipleUse = false;
  private bool isInteractable = true;
  private bool deactivateInteraction = false;
  public float HoldDuration
  {
    get { return holdDuration; }
    set { holdDuration = value; }
  }

  public bool DeactivateInteraction => deactivateInteraction;
  public bool HoldInteract => holdInteract;
  public bool MultipleUse => multipleUse;
  public bool IsInteractable => isInteractable;

  public virtual void OnInteract()
  {
    Debug.Log("Interacted : " + gameObject.name);
    if(gameObject.tag.Equals("Weapon"))
    {
      var obj = gameObject.GetComponent<ItemBase>();
      Debug.Log("ItemBase");
      if(obj is not null)
      {
        obj.Equip();
      }
    }
  }
}
