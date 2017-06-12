using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	public float speed;
	public float forwardSpeed;
	public Texture[] textures;


	// Use this for initialization
	private Renderer rd;
	private bool incrementedScore;
	void Start () {
		rd = GetComponent<Renderer> ();
		//Debug.Log ("Texture Count =" + textures.Length);
		if (textures.Length != 0) {
			int ballIndex = Random.Range (0, textures.Length);
			rd.material.SetTexture (Shader.PropertyToID("_MainTex"), textures [ballIndex]);

	
		}
		incrementedScore = false;

	}

	// Update is called once per frame
	void LateUpdate () {
		if (transform.position.z < -5.0f && !incrementedScore) {
			incrementedScore = true;
			ScoreManager.score += 10;
		}
		if (transform.position.z < -60.0f)
			Destroy (gameObject);
		
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z-speed*Time.deltaTime);

		transform.Rotate(Vector3.right,forwardSpeed*Time.deltaTime,Space.World);
	}

}

