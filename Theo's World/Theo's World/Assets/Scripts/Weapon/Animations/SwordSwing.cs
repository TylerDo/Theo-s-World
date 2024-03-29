using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class SwordSwing : MonoBehaviour
{
  public GameObject Sword;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (!PauseController.isGamePaused)
    {
      if (Gamepad.current.squareButton.isPressed)
      {
        if (Sword.GetComponent<Sword>().IsEquipped)
        {
          StartCoroutine(SwordSwingAction());
        }
      }
    }
  }

  IEnumerator SwordSwingAction()
  {
    var player = GameObject.FindGameObjectWithTag("Player");
    Sword.GetComponent<SwordTrail>().EnableTrail();
    Sword.GetComponent<Animator>().Play("SwordSwing");
    yield return new WaitForSeconds(1.0f);
    Sword.GetComponent<Animator>().Play("New State");
    Sword.GetComponent<SwordTrail>().DisableTrail();
  }
}
