using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : VitalsSystem
{
  // Start is called before the first frame update
  void Start()
  {
    currentVitals = maxVitals;
  }

  // Update is called once per frame
  void Update()
  {
    if (Player.isSprinting)
    {
      FatiguePlayer(2);
    }
    else
    {
      RestPlayer(1);
    }
  }

  public void SetEnergy(int energy)
  {
    currentVitals = energy;
  }

  public void FatiguePlayer(int energyConsumption)
  {
    if (currentVitals > 0)
    {
      currentVitals -= energyConsumption;
      vitalsBar.SetValue(currentVitals);
    }
  }

  public void RestPlayer(int rest)
  {
    if (currentVitals < maxVitals)
    {
      currentVitals += rest;
      vitalsBar.SetValue(currentVitals);
    }
  }

  public void IncreaseMaxEnergy(int energyIncrease)
  {
    maxVitals += energyIncrease;
  }
}
