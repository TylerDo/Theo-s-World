using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
  //float to determine how long a button should be pressed to realize interaction
  float HoldDuration { get; }
  //Boolean to know if the button to interact should be hold pressed
  bool HoldInteract { get; }
  //Boolean to know if multiple uses are possible
  bool MultipleUse { get; }
  //Boolean to know if the interactable is still interactable (unique interaction for instance_
  bool IsInteractable { get; }
  //Generic interaction method
  void OnInteract();
}
