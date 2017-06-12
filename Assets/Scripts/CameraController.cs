using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;       //to store a reference to the player object. Needs to be set from the Main Camera Inspector

	private Vector3 offset;


	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position; // To calculate the offset between the camera and the player object 
	

	}
	
	// LateUpdate is called after all Update functions have been called, hence camera can track all the changes in the current frame
	void LateUpdate () {
		transform.position = player.transform.position + offset; //move the camera along with the player

	}
}
