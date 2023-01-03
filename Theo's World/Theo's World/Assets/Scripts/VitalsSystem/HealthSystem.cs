using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : VitalsSystem
{
  // Start is called before the first frame update
  void Start()
  {
    currentVitals = maxVitals;
  }

  // Update is called once per frame
  void Update()
  {
    if(Player.isHurt)
    {
      DamagePlayer(Player.Damage);
    }
    else
    {
      HealPlayer(1);
    }
  }

  public void SetHealth(int health)
  {
    currentVitals = health;
  }

  public void DamagePlayer(int damage)
  {
    if (currentVitals > 0)
    {
      currentVitals -= damage;
      vitalsBar.SetValue(currentVitals);
    }
  }
  
  public void HealPlayer(int healing)
  {
    if (currentVitals < maxVitals)
    {
      currentVitals += healing;
      vitalsBar.SetValue(currentVitals);
    }
  }

  public void IncreaseMaxHealth(int healingIncrease)
  {
    maxVitals += healingIncrease;
  }

}
