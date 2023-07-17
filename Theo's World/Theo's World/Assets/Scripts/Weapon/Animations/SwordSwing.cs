using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    if (Gamepad.current.squareButton.wasPressedThisFrame)
    {
      StartCoroutine(SwordSwingAction());
    }
  }

  IEnumerator SwordSwingAction()
  {
    Sword.GetComponent<Animator>().Play("SwordSwing");
    yield return new WaitForSeconds(1.0f);
    Sword.GetComponent<Animator>().Play("New State");
  }
}
