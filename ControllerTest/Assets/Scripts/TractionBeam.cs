using UnityEngine;
using System.Collections;

public class TractionBeam : MonoBehaviour {

    public GameObject grabbedObject;
    public Camera cameraVector;
    public float retractSpeed = 0.3f;
    public float objectMaxDis = 40;

    Transform cam = Camera.main.transform;
    RaycastHit hit;
    bool gotObject = false;
    bool canShoot = true;
    float depth;
    
    
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // this is for picking up the objects
        if (Input.GetButtonDown("Trigger") && !gotObject)
        {

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));


            if (Physics.Raycast(ray, out hit, objectMaxDis) && !gotObject)
            {
                if (hit.transform.tag == "MovableObject" || hit.transform.tag == "Collectible")
                {
                    if (hit.transform.tag == "Collectible")
                    {
                        Debug.Log("detected");
                        GetComponentInChildren<BoxCollider>().isTrigger = true;
                    }

                    grabbedObject = hit.transform.gameObject;
                    hit.rigidbody.useGravity = false;
                    gotObject = true;
                    depth = hit.distance;

                    canShoot = false;
                    StartCoroutine(timer());
                }
            }
        }

        // this is for retracting an object when you have something
        if (gotObject)
        {
            grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            Vector3 lookPos = cameraVector.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, depth));
            grabbedObject.transform.position = lookPos;


            if (Input.GetButton("Button2") && hit.distance >= 2 && depth < objectMaxDis)
            {
                GetComponent<TestControllerThree>().enabled = false;
                
                if (Input.GetAxis("JoystickHorizontal") >= 0.1)
                {
                    depth -= retractSpeed;
                }
                else if(Input.GetAxis("JoystickHorizontal") <= -0.1)
                {
                    depth += retractSpeed;
                }
            }
            else if (Input.GetButtonUp("Button2") || depth > objectMaxDis)
            {
                GetComponent<TestControllerThree>().enabled = true;
            }

            //for dropping object
            if(Input.GetButton("Button2") && Input.GetButton("Trigger"))
            {
                GetComponent<TestControllerThree>().enabled = true;
                grabbedObject.GetComponent<Rigidbody>().useGravity = true;
                grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                grabbedObject = null;
                gotObject = false;
            }

            //when the object is further than it should be it drops
            if (depth > objectMaxDis)
            {
                GetComponent<TestControllerThree>().enabled = true;
                grabbedObject.GetComponent<Rigidbody>().useGravity = true;
                grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                grabbedObject = null;
                gotObject = false;
            }
        }

        // this is for shooting an object away
        if (Input.GetButtonDown("Trigger") && gotObject && canShoot)
        {
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            grabbedObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 4000);

            grabbedObject = null;
            gotObject = false;
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.2f);
        canShoot = true;

    }
}
