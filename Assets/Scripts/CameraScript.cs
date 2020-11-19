using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    GameObject target;

    private void Start()
    {
        target = FindObjectOfType<PlayerController>().gameObject;
    }
    private void Update()
    {
        FollowTarget();
    }
    void FollowTarget()
    {
        transform.position = Vector3.Slerp(transform.position, target.transform.position + offset, 0.15f);
    }
}
