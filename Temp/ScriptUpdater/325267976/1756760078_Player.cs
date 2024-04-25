using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float maxRaycastDistance = 100f;

    void Start()
    {
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        // Movement controls
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * 0.05f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * 0.05f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * 0.05f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * 0.05f;
        }

        // Rotation controls
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, 0.5f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down, 0.5f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.left, 0.5f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right, 0.5f);
        }

        // Raycast from the main camera
        Ray ray = Camera.main.ViewportPointToRay(GetComponent<Camera>().forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxRaycastDistance))
        {
            lineRenderer.SetPosition(0, ray.origin);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(0, ray.origin);
            lineRenderer.SetPosition(1, ray.origin + ray.direction * maxRaycastDistance);
        }
    }
}
