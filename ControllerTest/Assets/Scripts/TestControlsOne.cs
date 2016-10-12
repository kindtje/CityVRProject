using UnityEngine;
using System.Collections;

public class TestControlsOne : MonoBehaviour {


    public Camera cam;
    Rigidbody rigid;

    // Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
       
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxis("JoystickVertical");
        inputDirection.z = Input.GetAxis("JoystickHorizontal");

        //if ((inputDirection.x >= 0.1 || inputDirection.x <= -0.1) || (inputDirection.z >= 0.1 || inputDirection.z <= -0.1))
          //  transform.Translate(inputDirection.x / 2, 0, -inputDirection.z  / 2);

        if(inputDirection.x >= 0.1f || inputDirection.x <= -0.1f)
        {
            transform.Translate(Vector3.right * inputDirection.x / 2);
        }
        if(inputDirection.z >= 0.1 || inputDirection.z <= -0.1)
        {
            transform.Translate(Vector3.forward * -inputDirection.z / 2);
        }
        //this is for testing without right controller
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3());
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(cam.transform.right * 1);
        }
        //till here
        
        if (Input.GetButton("Button3") || Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, -1, 0), Space.World);
        }
        if (Input.GetButton("Button4") || Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 1, 0), Space.World);
        }
    }
}
