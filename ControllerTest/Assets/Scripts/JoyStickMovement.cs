using UnityEngine;
using System.Collections;

public class JoyStickMovement : MonoBehaviour {
	public float rotationReducer = 2.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 inputDirection = Vector3.zero;
		inputDirection.x = Input.GetAxis("JoystickVertical");
		inputDirection.z = Input.GetAxis("JoystickHorizontal");

		if ((inputDirection.x >= 0.1 || inputDirection.x <= -0.1) || (inputDirection.z >= 0.1 || inputDirection.z <= -0.1))
			transform.Rotate(new Vector3(inputDirection.x / rotationReducer, 0, -inputDirection.z  / rotationReducer));



	}
}
