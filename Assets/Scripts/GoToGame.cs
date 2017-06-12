using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour {

	// Use this for initialization
	public void GoToPlayArea()
	{
		
		SceneManager.LoadScene ("scene1", LoadSceneMode.Single);
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit ();
		}

	}
}
