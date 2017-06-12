using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour {

	public float speed;
	public GameObject path;
	public GameObject enemy;
	//public GameObject player;

	private Vector3 startPos; //only z value is needed
	private bool createdNewPath;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
		createdNewPath = false;
	}

	// Update is called once per frame
	void Update () {

		if (transform.position.z < -60.0f)
			Destroy (gameObject);
		if (!createdNewPath && transform.position.z<0.0f) {
			Instantiate (path,new Vector3(startPos.x,startPos.y,transform.position.z + 35),Quaternion.identity);
			InstantiateEnemies ();

			createdNewPath = true;
		}
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z-speed*Time.deltaTime);
	}

	void InstantiateEnemies(){
		
		float xoffset;
		float zoffset = 40;
		for (int i = 0; i < 10; i++) {
			xoffset = Random.Range (-1.2f, 1.2f);
			Instantiate (enemy, new Vector3 (startPos.x + xoffset, startPos.y + 0.15f, transform.position.z + zoffset), Quaternion.identity);
			zoffset -= 5;
		}
	}

}
