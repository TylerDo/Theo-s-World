using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
  public Light Sun;
  public Light Moon;
  public float lengthOfDay = 60f;
  public float timeScale = 1f;
  private float timeOfDay = 0f;

  void Update()
  {
    timeOfDay += Time.deltaTime * timeScale;
    if (timeOfDay > lengthOfDay)
    {
      timeOfDay -= lengthOfDay;
    }
    float sunAngle = (timeOfDay / lengthOfDay) * 360f;
    Sun.transform.rotation = Quaternion.Euler(sunAngle, 0, 0);
    float moonAngle = sunAngle - 180f;
    Moon.transform.rotation = Quaternion.Euler(moonAngle, 0, 0);
    if (sunAngle > 90f && sunAngle < 270f)
    {
      Sun.enabled = false;
      Moon.enabled = true;
    }
    else
    {
      Sun.enabled = true;
      Moon.enabled = false;
    }
  }
}
