using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PauseController
{
  public static bool isGamePaused;
  public static void PauseGame()
  {
    isGamePaused = !isGamePaused;
    if(isGamePaused)
    {
      Time.timeScale = 0;
    }
    else
    {
      Time.timeScale = 1;
    }
  }
}
