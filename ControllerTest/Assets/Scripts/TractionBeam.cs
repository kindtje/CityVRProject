using UnityEngine;
using System.Collections;

public class TractionBeam : MonoBehaviour {

    Transform cam = Camera.main.transform;
    public GameObject grabbedObject;
    bool gotObject = false;
    public Camera cameraVector;
    float depth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetButton("Trigger") || Input.GetMouseButton(0))
        {          

            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

         
            if (Physics.Raycast(ray, out hit, 20) && !gotObject)
            {
                if(hit.transform.tag == "MovableObject")
                grabbedObject = hit.transform.gameObject;
                hit.rigidbody.useGravity = false;
                hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 1.5f, hit.transform.position.z);
                gotObject = true;
                depth = hit.distance;
            }

            //grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            Vector3 lookPos = cameraVector.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, depth));
            grabbedObject.transform.position = new Vector3(lookPos.x, grabbedObject.transform.position.y, lookPos.z);

            if ((Input.GetButton("Button2") || Input.GetMouseButton(1)) && hit.distance >= 2)
            {
                depth -= 0.5f;
            }

        }
        if(Input.GetButtonUp("Trigger") || Input.GetMouseButtonUp(0))
        {
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            if (Input.GetButton("Button2") || Input.GetMouseButton(1))
                grabbedObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 4000);
            
                grabbedObject = null;
                gotObject = false;
        }
	}
}
