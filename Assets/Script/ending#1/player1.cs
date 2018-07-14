using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player1 : MonoBehaviour {
	
	// Use this for initialization
		public GameObject cam;
		private Vector3 distance;
		public GameObject ca;
	public AudioSource driver,driver2;
	public AudioClip clip,win;
	// Update is called once per frame
	public bool sound1,sound2 = true;
		public int count =0;
		void Start(){
				distance = cam.transform.position-transform.position;
				Hashtable ht = new Hashtable ();
				ht.Add ("a", 0f); 
				ht.Add ("time", 5f);
				iTween.ColorFrom (ca, ht);
		}
	void Update () {
				if (count <= 200) {
						transform.localScale += new Vector3 (0.001f, 0.001f, 0.001f);
						if (sound1) {
							driver.PlayOneShot (clip);
							sound1 = false;
						}

				} else {
			
						transform.position += new Vector3 (0, -0.01f, 0);
						cam.transform.position = transform.position + distance;
				}
				if (count == 150) {
					driver2.PlayOneShot (win);
				}
				count += 1;
	}
}
