using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
  public GameObject newGameMenu;
  public GameObject loadGameMenu;
  public GameObject optionsMenu;
  public GameObject settingsMenu;
  public GameObject mainMenu;
  public Collection<Button> menuButtons = new Collection<Button>();
  public Collection<Canvas> menus;
  private DualShock4GamepadHID PS4Controller;
  private int selectedIndex = 0;
  public float navigationThreshold = 0.5f; // The threshold for navigating between buttons
  private bool canNavigate = true; // Whether or not navigation is currently allowed
  private float lastInputTime = 0f; // The time of the last input event
  public float inputDelay = 0.2f; // The delay between input events in seconds
  private bool isVerticalButtonLayout = true;
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
    menuButtons = new Collection<Button>(mainMenu.GetComponentsInChildren<Button>());
    foreach (Button b in menuButtons)
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
          ButtonNavigation();
        }
        else
        {
          if (PS4Controller.leftStick.ReadValue() == Vector2.zero && PS4Controller.dpad.ReadValue() == Vector2.zero)
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
        if (PS4Controller.circleButton.isPressed)
        {
          GoBacktoMainMenu();
        }
      }
    }
  }

  private void ButtonNavigation()
  {
    if (isVerticalButtonLayout)
    {
      if (PS4Controller.leftStick.down.isPressed || PS4Controller.dpad.down.isPressed)
      {
        Debug.Log("Down");
        if (selectedIndex < menuButtons.Count - 1)
        {
          SelectButton(selectedIndex + 1);
          canNavigate = false;
          lastInputTime = Time.time;
        }
      }
      else if (PS4Controller.leftStick.up.isPressed || PS4Controller.dpad.up.isPressed)
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
      if (PS4Controller.leftStick.right.isPressed || PS4Controller.dpad.right.isPressed)
      {
        Debug.Log("Down");
        if (selectedIndex < menuButtons.Count - 1)
        {
          SelectButton(selectedIndex + 1);
          canNavigate = false;
          lastInputTime = Time.time;
        }
      }
      else if (PS4Controller.leftStick.left.isPressed || PS4Controller.dpad.left.isPressed)
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

  private void GoBacktoMainMenu()
  {
    Debug.Log("GobackToMainMenu");
    if(mainMenu is not null)
    {
      mainMenu.SetActive(true);
    }
    if (newGameMenu is not null)
    {
      newGameMenu.SetActive(false);
    }
    if (loadGameMenu is not null)
    {
      loadGameMenu.SetActive(false);
    }
    if (optionsMenu is not null)
    {
      optionsMenu.SetActive(false);
    }
    if (settingsMenu is not null)
    {
      settingsMenu.SetActive(false);
    }
    menuButtons = new Collection<Button>(mainMenu.GetComponentsInChildren<Button>());
  }
   
  public void UpdateButtonCollection(GameObject button)
  {
    menuButtons = button.name switch
    {
      "NewGameButton" => new Collection<Button>(newGameMenu.GetComponentsInChildren<Button>()),
      "LoadGameButton" => new Collection<Button>(loadGameMenu.GetComponentsInChildren<Button>()),
      "OptionsButton" => new Collection<Button>(optionsMenu.GetComponentsInChildren<Button>()),
      "SettingsButton" => new Collection<Button>(settingsMenu.GetComponentsInChildren<Button>()),
      _ => new Collection<Button>(mainMenu.GetComponentsInChildren<Button>()),
    };
    isVerticalButtonLayout = button.name switch
    {
      "NewGameButton" => true,
      "LoadGameButton" => true,
      "OptionsButton" => false,
      "SettingsButton" => false,
      _ => true,
    };
    foreach (Button b in menuButtons)
    {
      Debug.Log(b);
    }
  }
}
