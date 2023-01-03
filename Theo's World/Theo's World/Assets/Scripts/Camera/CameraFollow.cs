using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [SerializeField] private Transform Target;
  [SerializeField] private float SmoothTime;
  private Vector3 Offset;
  private Vector3 CurrentVelocity = Vector3.zero;

  private void Awake()
  {
    Offset = transform.position - Target.position;
  }

  private void LateUpdate()
  {
    Vector3 TargetPostion = Target.position + Offset;
    transform.position = Vector3.SmoothDamp(transform.position, TargetPostion, ref CurrentVelocity, SmoothTime);
  }
}
