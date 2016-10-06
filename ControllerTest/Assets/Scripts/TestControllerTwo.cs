using UnityEngine;
using System.Collections;

public class TestControllerTwo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 inputDirection = Vector3.zero;
        inputDirection.z = Input.GetAxis("JoystickHorizontal");

        if (inputDirection.z >= 0.1 || inputDirection.z <= -0.1)
            transform.Translate(0, 0, -inputDirection.z / 2);

        Debug.Log("x: " + inputDirection.x);
        Debug.Log("y: " + inputDirection.z);

        Vector3 rotateDirection = Vector3.zero;
        rotateDirection.y = Input.GetAxis("JoystickVertical");

        if(rotateDirection.y >= 0.1 || rotateDirection.y <= -0.1)
        {
            transform.Rotate(rotateDirection);
        }
    }
}
