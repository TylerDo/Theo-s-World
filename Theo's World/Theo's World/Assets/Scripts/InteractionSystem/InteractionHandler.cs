using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class InteractionHandler : MonoBehaviour
{
  public InteractionInputData interactionInputData;
  // Start is called before the first frame update
  void Start()
  {
    interactionInputData.ResetInput();
  }

  // Update is called once per frame
  void Update()
  {
    GetInterationInputData();
  }

  void GetInterationInputData()
  {
    //only works for ps4 controll atm...
    interactionInputData.InteractedClicked = Gamepad.all.First().squareButton.wasPressedThisFrame;
    interactionInputData.InteractedReleased = Gamepad.all.First().squareButton.wasReleasedThisFrame;
  }
}
