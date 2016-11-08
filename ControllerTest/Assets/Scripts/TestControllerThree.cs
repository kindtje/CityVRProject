using UnityEngine;
using System.Collections;

public class TestControllerThree : MonoBehaviour {

    public float speed = 0.5f;
    public float rotSpeed = 0.5f;
    public Camera cam;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 inputDirection = Vector3.zero;
        inputDirection.z = Input.GetAxis("JoystickHorizontal");

        if (inputDirection.z >= 0.1 || inputDirection.z <= -0.1)
            transform.Translate(0, 0, -inputDirection.z);

        Debug.Log("x: " + inputDirection.x);
        Debug.Log("y: " + inputDirection.z);

        Vector3 rotateDirection = Vector3.zero;
        rotateDirection.y = Input.GetAxis("JoystickVertical");

        if (rotateDirection.y >= 0.1)
        {
            transform.Rotate(rotateDirection = new Vector3(rotateDirection.x, rotSpeed, rotateDirection.z));
        }
        else if (rotateDirection.y <= -0.1)
        {
            transform.Rotate(rotateDirection = new Vector3(rotateDirection.x, - rotSpeed, rotateDirection.z));
        }

        if (Input.GetButton("Button3") || Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.right * -speed);
        }
        if (Input.GetButton("Button4") || Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.right * speed);
        }
    }
}
