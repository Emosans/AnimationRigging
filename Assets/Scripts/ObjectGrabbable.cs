using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    //public Transform grabPoint;
    private Rigidbody objectRigidbody;
    private Transform grabPoint;
    public GameObject textPanel;
    public TextMeshProUGUI textMeshPro;
    public Transform pickUpPoint;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        //textMeshPro = GetComponent<TextMeshPro>();
    }

    public void Grab(Transform objectGrabPoint)
    {
        this.grabPoint = objectGrabPoint;
        //textPanel.SetActive(false);
        textMeshPro.text = "Press 'E' to drop object";
        objectRigidbody.useGravity = false;
        
    }

    public void Drop()
    {
        this.grabPoint = null;
        textMeshPro.text = "Press 'E' to pickup object";
        gameObject.SetActive(true);
        gameObject.transform.SetParent(null);
        
        objectRigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (grabPoint != null)
        { 
            gameObject.transform.SetParent(pickUpPoint);
            gameObject.transform.localPosition = Vector3.zero;
            //gameObject.SetActive(false);
            float lerpSpeed = 5f;
            Vector3 newPosition = Vector3.Lerp(transform.position,pickUpPoint.position,Time.deltaTime*lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
            Debug.Log("Object picked up");
        }
    }
}
