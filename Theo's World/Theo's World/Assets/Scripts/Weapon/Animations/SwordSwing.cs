using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    if (Gamepad.current.squareButton.wasPressedThisFrame)
    {
      if (Sword.GetComponent<Sword>().IsEquipped)
      {
        StartCoroutine(SwordSwingAction());
      }
    }
  }

  IEnumerator SwordSwingAction()
  {
    var player = GameObject.FindGameObjectWithTag("Player");
    // Calculate the angle between the character's forward vector and the desired direction
    //Vector3 desiredDirection = /* the direction you want the object to face */
    //float angle = Vector3.SignedAngle(player.transform.forward, desiredDirection, Vector3.up);

    // Rotate the object around its local y axis by the calculated angle
    Sword.GetComponent<Animator>().transform.LookAt(-player.transform.position);
    Sword.GetComponent<Animator>().Play("SwordSwing");
    yield return new WaitForSeconds(1.0f);
    Sword.GetComponent<Animator>().Play("New State");
  }
}
