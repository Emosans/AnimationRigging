using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class LookAtObject : MonoBehaviour
{
    private Rig rig;
    private float targetWeight;
    void Awake()
    {
        rig = GetComponent<Rig>();
    }

    private void Update()
    {
        rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime*5f);

        if (Input.GetKeyDown(KeyCode.F))
        {
            targetWeight = 1f;
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            targetWeight = 0f;
        }
    }
}
