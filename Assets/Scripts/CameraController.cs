using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget;

    private Vector3 offset;

    void Start()
    {
        offset = followTarget.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = followTarget.position - offset;
    }
}
