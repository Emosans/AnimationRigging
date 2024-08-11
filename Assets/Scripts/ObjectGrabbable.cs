using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    //public Transform grabPoint;
    private Rigidbody objectRigidbody;
    private Transform grabPoint;
    public GameObject textPanel;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPoint)
    {
        this.grabPoint = objectGrabPoint;
        textPanel.SetActive(false);
        objectRigidbody.useGravity = false;
    }

    public void Drop()
    {
        this.grabPoint = null;
        gameObject.SetActive(true);
        gameObject.transform.SetParent(null);
        objectRigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (grabPoint != null)
        {
            gameObject.transform.SetParent(grabPoint);
            gameObject.transform.localPosition = Vector3.zero;
            
            gameObject.SetActive(false);
            //float lerpSpeed = 5f;
            //Vector3 newPosition = Vector3.Lerp(transform.position,grabPoint.position,Time.deltaTime*lerpSpeed);
            //objectRigidbody.MovePosition(newPosition);
            Debug.Log("Object picked up");
        }
    }
}
