using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMgr : MonoBehaviour
{
    private Transform grabObject;
    private bool isTouched = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            grabObject.SetParent(this.transform);
            grabObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            grabObject.SetParent(null);

            Vector3 _velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            grabObject.GetComponent<Rigidbody>().isKinematic = false;
            grabObject.GetComponent<Rigidbody>().velocity = _velocity;

            isTouched = false;
            grabObject = null;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("BALL"))
        {
            isTouched = true;
            grabObject = coll.transform;
        }
    }
}
