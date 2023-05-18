using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] Transform TargetToFollow;
    void LateUpdate()
    {
        transform.position = TargetToFollow.position + offset;
        transform.LookAt(TargetToFollow);
    }
}
