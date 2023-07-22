using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrail : MonoBehaviour
{
  public TrailRenderer trail; // The trail renderer attached to the sword

  public void Start()
  {
    trail.enabled = false;
  }
  public void EnableTrail()
  {
    // Enable the trail renderer
    trail.enabled = true;
  }

  public void DisableTrail()
  {
    // Disable the trail renderer
    trail.enabled = false;
  }
}