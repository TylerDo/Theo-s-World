using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public interface IWeapon
{
  int AttackPower { get; }
  bool IsEquipped { get; }
  void Attack();
}
