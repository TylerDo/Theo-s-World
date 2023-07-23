using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
  public GameObject menu;
  public Collection<Button> menuButtons = new Collection<Button>();
  private DualShock4GamepadHID PS4Controller;
  private int selectedIndex = 0;
  public float navigationThreshold = 0.5f; // The threshold for navigating between buttons
  private bool canNavigate = true; // Whether or not navigation is currently allowed
  private float lastInputTime = 0f; // The time of the last input event
  public float inputDelay = 0.2f; // The delay between input events in seconds
  void Start()
  {
    foreach (Gamepad gp in Gamepad.all)
    {
      if (gp.GetType() == typeof(DualShock4GamepadHID))
      {
        PS4Controller = (DualShock4GamepadHID)gp;
      }
    }
    // Find all Button components that are children of the menu game object
    menuButtons = new Collection<Button>(menu.GetComponentsInChildren<Button>());
    foreach(Button b in menuButtons)
    {
      Debug.Log(b);
    }
    // Select the first button by default
    SelectButton(0);
  }

    // Update is called once per frame
    void Update()
    {
    // Check if enough time has passed since the last input event
    if (Time.time - lastInputTime > inputDelay)
    {
      // Check if navigation is allowed
      if (PS4Controller is not null)
      {
        // Check if navigation is allowed
        if (canNavigate)
        {
          if (PS4Controller.leftStick.down.isPressed)
          {
            Debug.Log("Down");
            if (selectedIndex < menuButtons.Count - 1)
            {
              SelectButton(selectedIndex + 1);
              canNavigate = false;
              lastInputTime = Time.time;
            }
          }
          else if (PS4Controller.leftStick.up.isPressed)
          {
            Debug.Log("Up");

            if (selectedIndex > 0)
            {
              SelectButton(selectedIndex - 1);
              canNavigate = false;
              lastInputTime = Time.time;
            }
          }
        }
        else
        {
          if(PS4Controller.leftStick.ReadValue() == Vector2.zero)
          {
            canNavigate = true;
          }
        }

        // Check if the "Submit" button was pressed
        if (PS4Controller.crossButton.isPressed)
        {
          Debug.Log("Selecting button " + selectedIndex.ToString());
          // Activate the currently selected button
          menuButtons[selectedIndex].onClick.Invoke();
        }
      }
    }
  }

  void SelectButton(int index)
  {
    // Clamp the index to a valid range
    index = Mathf.Clamp(index, 0, menuButtons.Count - 1);

    // Deselect the previously selected button
    var deselectedButton = menuButtons[selectedIndex];
    deselectedButton.OnDeselect(null);

    // Select the new button
    var selectedButton = menuButtons[index];
    selectedButton.Select();
    selectedButton.OnSelect(null);
    selectedIndex = index;
  }
}
