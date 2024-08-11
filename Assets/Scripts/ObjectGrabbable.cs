using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    //public Transform grabPoint;
    private Rigidbody objectRigidbody;
    private Transform grabPoint;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPoint)
    {
        this.grabPoint = objectGrabPoint;
        objectRigidbody.useGravity = false;
    }

    public void Drop()
    {
        this.grabPoint = null;
        objectRigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (grabPoint != null)
        {
            float lerpSpeed = 5f;
            Vector3 newPosition = Vector3.Lerp(transform.position,grabPoint.position,Time.deltaTime*lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }
}
