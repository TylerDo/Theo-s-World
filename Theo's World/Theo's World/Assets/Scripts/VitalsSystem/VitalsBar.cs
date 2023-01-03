using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalsBar : MonoBehaviour
{
  public Slider vitalsBar;
  public VitalsSystem playerVitals;
  // Start is called before the first frame update
  void Start()
  {
    playerVitals = GameObject.FindGameObjectWithTag("Player").GetComponent<VitalsSystem>();
    vitalsBar = GetComponent<Slider>();
    vitalsBar.maxValue = playerVitals.maxVitals;
    vitalsBar.value = playerVitals.maxVitals;
  }

  public void SetValue(int value)
  {
    vitalsBar.value = value;
  }

}
