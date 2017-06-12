using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Controls the player motion
public class PlayerController : MonoBehaviour {

	public float controlSpeed;          //set the speed of the movement on pression motion keys.  Needs to be set via inspector
	public float forwardSpeed; 			//speed at which the ball moves forward
	private Rigidbody rb;
	public SimpleTouchPad touchPad;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();          //get a reference to the rigidbody parameter of an object to control the motion

	}
	
	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled
	void FixedUpdate () 
	{
		//float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector2 touchPoint = touchPad.GetTouchedPoint ();
		if (touchPoint != Vector2.zero) 
		{
			//Debug.Log ("Touched screen at point: " + touchPoint);
			//Debug.Log ("Screen width: " + Screen.width);
			Vector3 movement;
			if (touchPoint.x < Screen.width / 2) {
				movement = new Vector3 (-1, 0.0f, 0.0f);  //There should not be be any action upwards or downwards so Y axis motion is set to zero and the player can only control moving to the left or right. So the Z axis is set to zero
			}
			else 
			{
				movement = new Vector3 (1, 0.0f, 0.0f);  //There should not be be any action upwards or downwards so Y axis motion is set to zero and the player can only control moving to the left or right. So the Z axis is set to zero

			}
			rb.AddForce (movement * controlSpeed); //implement motion with a certain speed
		}

		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f,0.0f);     //There should not be be any action upwards or downwards so Y axis motion is set to zero and the player can only control moving to the left or right. So the Z axis is set to zero
		//rb.AddForce (movement * controlSpeed); //implement motion with a certain speed

	}


	//called every frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Escape)){
			SceneManager.LoadScene ("menuScene", LoadSceneMode.Single);
		}
		transform.Rotate(Vector3.right,forwardSpeed*Time.deltaTime,Space.World);

	
	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.tag == "Enemy") {
			
			Destroy (other.gameObject);
		}
	}
}
