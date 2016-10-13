using UnityEngine;
using System.Collections;

public class VirtualController : MonoBehaviour {

    float rotationMax = 10;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxis("JoystickVertical");
        inputDirection.z = Input.GetAxis("JoystickHorizontal");



        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.Rotate(Vector3.forward * rotationMax * -inputDirection.x);
        transform.Rotate(Vector3.right * rotationMax * -inputDirection.z);

    }
}
