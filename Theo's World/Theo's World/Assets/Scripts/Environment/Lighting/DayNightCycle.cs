using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
  public Light Sun;
  public Light Moon;
  public float lengthOfDay = 60f;
  public float lengthOfNight = 60f;
  public float timeScale = 1f;
  private float timeOfDay = 0f;
  public float minAngle = 60f; // Minimum angle of sun/moon movement
  public float maxAngle = 120f; // Maximum angle of sun/moon movement

  void Update()
  {
    timeOfDay += Time.deltaTime * timeScale;
    if (timeOfDay > lengthOfDay + lengthOfNight)
    {
      timeOfDay -= lengthOfDay + lengthOfNight;
    }
    // Calculate the angle of the sun and moon based on the current time of day, the minimum and maximum angles, and the length of day and night
    float sunAngle, moonAngle;
    if (timeOfDay < lengthOfDay)
    {
      sunAngle = Mathf.Lerp(minAngle, maxAngle, timeOfDay / lengthOfDay);
      Sun.transform.rotation = Quaternion.Euler(sunAngle, 0, 0);
    }
    else
    {
      //sunAngle = Mathf.Lerp(maxAngle, minAngle, (timeOfDay - lengthOfDay) / lengthOfNight);
      moonAngle = Mathf.Lerp(minAngle, maxAngle, (timeOfDay - lengthOfDay) / lengthOfNight);
      Moon.transform.rotation = Quaternion.Euler(moonAngle, 0, 0);
    }
    // Rotate the sun and moon to the calculated angles
    if (timeOfDay < lengthOfDay)
    {
      Sun.enabled = true;
      Moon.enabled = false;
    }
    else
    {
      Sun.enabled = false;
      Moon.enabled = true;
    }
  }
}
