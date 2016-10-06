using UnityEngine;
using System.Collections;

public class TestControlsOne : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxis("JoystickVertical");
        inputDirection.z = Input.GetAxis("JoystickHorizontal");

        if ((inputDirection.x >= 0.1 || inputDirection.x <= -0.1) || (inputDirection.z >= 0.1 || inputDirection.z <= -0.1))
            transform.Translate(inputDirection.x / 2, 0, -inputDirection.z  / 2);

        if(Input.GetButton("Button3"))
        {
            transform.Rotate(new Vector3(0, -1, 0));
        }
        if (Input.GetButton("Button4"))
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }
    }
}
