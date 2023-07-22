using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
  [Header("Data")]
  public InteractionInputData interactionInputData;
  public InteractionData interactionData;
  [Space]
  [Header("Ray Settings")]
  public float rayDistance;
  public float raySphereRadius;
  public LayerMask interactableLayer;
  private Camera camera;
  private bool isInteracting;
  private float holdTimer = 0f;
  public float HoldTimer => holdTimer;

  private void Awake()
  {
    //Find camera on awake
    camera = FindObjectOfType<Camera>();
  }

  private void Update()
  {
    CheckForInteractable();
    CheckForInteractableInput();
  }

  private void CheckForInteractable()
  {

    var ray = new Ray(transform.position, transform.forward);
    //bool hitSomething = Physics.SphereCast(ray, raySphereRadius, out RaycastHit hitInfo, rayDistance, interactableLayer);
    RaycastHit hitInfo;
    bool hitSomething = Physics.Raycast(transform.position, transform.forward, out hitInfo, rayDistance, interactableLayer);
    if (hitSomething)
    {
      Debug.Log("Raycast hit: " + hitInfo.collider.name);
    }
    if (hitSomething)
    {
      var interactable = hitInfo.transform.GetComponent<InteractableBase>();

      if (interactable != null)
      {
        if (interactionData.IsEmpty())
        {
          interactionData.Interactable = interactable;
        }
        else
        {
          if (interactionData.IsSameInteractable(interactable))
          {
            interactionData.Interactable = interactable;
          }
        }
      }
    }
    else
    {
      interactionData.ResetData();
    }

    Debug.DrawRay(ray.origin, ray.direction * rayDistance, hitSomething ? Color.green : Color.red);

    
    //if (hitSomething)
    //{
    //  OnMouseOver();
    //}
    //else
    //{
    //  OnMouseExit();
    //}
  }

  void CheckForInteractableInput()
  {
    if (interactionData.IsEmpty() || interactionData.Interactable.DeactivateInteraction)
    {
      return;
    }
    if (interactionInputData.InteractedClicked)
    {
      isInteracting = true;
      holdTimer = 0f;
    }
    if (interactionInputData.InteractedReleased)
    {
      isInteracting = false;
      holdTimer = 0f;
    }
    if (isInteracting)
    {
      if (interactionData.Interactable.IsInteractable)
      {
        if (interactionData.Interactable.HoldInteract)
        {
          holdTimer += 1;
          if (holdTimer >= interactionData.Interactable.HoldDuration)
          {
            interactionData.Interact();
            isInteracting = false;
          }
        }
        else
        {
          interactionData.Interact();
          isInteracting = false;
        }
      }
      return;
    }
  }

}
