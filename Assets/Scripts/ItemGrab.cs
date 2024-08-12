using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textPanel;
    public LayerMask layerMask;
    public Transform grabPoint;
    private ObjectGrabbable grabbable;
    
    private void Awake()
    {
        textPanel.SetActive(false);
    }

    private void Update()
    {
        ItemHit();
    }

    public void ItemHit()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(grabbable == null)
            {
                if (Physics.Raycast(grabPoint.position, grabPoint.forward, out RaycastHit raycastHit, 5f, layerMask) && raycastHit.transform.TryGetComponent(out grabbable))
                {
                    //if (raycastHit.transform.TryGetComponent(out grabbable))
                    
                        grabbable.Grab(grabPoint);

                    
                }
            }
            else
            {
                grabbable.Drop();
                grabbable = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            textPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            textPanel.SetActive(false);
        }
    }
}
