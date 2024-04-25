using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LineRenderer line;
    private Vector3 destination;

    void Start()
    {
        line.positionCount = 2;
        destination = transform.position;
    }

    void Update()
    {
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

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                destination = hit.point;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, destination);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoveToDestination());
        }
    }

    /*
    * Coroutine allows for the method to pause operations and continue in the next frame.
    */
    IEnumerator MoveToDestination()
    {
        GetComponent<Rigidbody>().useGravity = false;

        while (Vector3.Distance(transform.position, destination) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.1f);
            yield return null;
        }

        GetComponent<Rigidbody>().useGravity = true;
    }   
}
