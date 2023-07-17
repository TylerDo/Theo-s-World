using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionInputData", menuName = "InteractionSystem/InputData")]
public class InteractionInputData : ScriptableObject
{
  private bool interactedClicked;
  private bool interactedReleased;
  public bool InteractedClicked
  {
    get => interactedClicked;
    set => interactedClicked = value;
  }
  public bool InteractedReleased
  {
    get => interactedReleased;
    set => interactedReleased = value;
  }
  public void ResetInput()
  {
    interactedReleased = false;
    interactedClicked = false;
  }
}
