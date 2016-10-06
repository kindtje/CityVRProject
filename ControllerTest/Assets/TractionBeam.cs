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
	
        if(Input.GetButton("Trigger"))
        {
            Debug.Log("shot");
           

            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

         
            if (Physics.Raycast(ray, out hit, 100.0f) && !gotObject)
            {
                if(hit.transform.tag == "MovableObject")
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
                grabbedObject = hit.transform.gameObject;
                hit.rigidbody.useGravity = false;
                hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 5, hit.transform.position.z);
                gotObject = true;
                depth = 10;
            }

            Vector3 lookPos = cameraVector.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, depth));
            grabbedObject.transform.position = new Vector3(lookPos.x, grabbedObject.transform.position.y, lookPos.z);

            if (Input.GetButton("Button2"))
            {
                depth -= 0.001f;
            }

        }
        if(Input.GetButtonUp("Trigger"))
        {
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            grabbedObject = null;
            gotObject = false;
        }
	}
}
