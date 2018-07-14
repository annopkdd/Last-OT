using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipMenu : MonoBehaviour {
		

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void onClickPlay() {
		SceneManager.LoadScene ("Main");
	}
}
