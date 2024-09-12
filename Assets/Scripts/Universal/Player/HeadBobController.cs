using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    [SerializeField, Range(0,0.5f)] private float amplitude = 0.015f;
    [SerializeField, Range(0,30)] private float frequency = 10f;

    [SerializeField] private Transform cam = null;
    [SerializeField] private Transform cameraHolder = null;

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = FootStepMotion();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
        cam.localPosition = temp;
        }
        FocusTarget();
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude * 2;
        return pos;
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + cameraHolder.localPosition.y, transform.position.z);
        pos += cameraHolder.forward * 15f;
        return pos;
    }
}
