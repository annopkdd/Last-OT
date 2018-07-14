using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player4Controller : MonoBehaviour {
		public GameObject ghost;
		public GameObject holywater;
		public GameObject cross;
		public GameObject youwin;
		public Animator anim;
		public int count=0;
		public int rotate = 0;
		public int state  = 1;
		public AudioSource driver;
		public AudioClip thw,win;
		private int state_sound = 1;
		public bool sound =true;
	void Start(){
		youwin.SetActive (false);
	}
	void Update () {
				if (state == 1) {
						if (holywater.transform.position.x >= 5.1) {
							if (state_sound == 1) {
								driver.PlayOneShot (thw);
								state_sound = 2;
							}
						}
						holywater.transform.position += new Vector3 (-0.1f, 0, 0);
						holywater.transform.Rotate (new Vector3 (0, 0, 15f), Space.World);
						if (holywater.transform.position.x <= -4.00 && rotate == 0) {
								holywater.SetActive (false);
								rotate = 1;
						}
						if (rotate == 1) {
								if (ghost.transform.rotation.z <= 0.5) {
										ghost.transform.Rotate (new Vector3 (0, 0, 5f), Space.World);
								} else {
										rotate = 2;
								}
						}
						if (rotate == 2) {
								if (ghost.transform.rotation.z > 0) {
										ghost.transform.Rotate (new Vector3 (0, 0, -5f), Space.World);
								} else {
										state = 2;
								}
						}
			
				} else if (state == 2) {
						if (rotate != 3) {
								ghost.transform.position += new Vector3 (0.05f, 0, 0);
								anim.SetBool ("isHunt", true);
						} else {
								anim.SetBool ("isHunt", false);
						}

						if (count >= 80) {
								if (cross.transform.position.x >= 3.9) {
									if (state_sound == 2) {
										driver.PlayOneShot (thw);
										state_sound = 3;
									}
								}
								cross.transform.position += new Vector3 (-0.1f, 0, 0);
								cross.transform.Rotate (new Vector3 (0, 0, 20f), Space.World);
						}
						if (ghost.transform.position.x > cross.transform.position.x || cross.transform.position.x < ghost.transform.position.x) {
								rotate = 3;
						}
						if (rotate == 3) {
								ghost.transform.Rotate (new Vector3 (0, 0, -25f), Space.World);
								if (count >= 250) {
										anim.SetBool ("isWarp", true);
										state = 3;
								}
						}
						count++;

				} else if (state == 3) {
						youwin.SetActive (true);
						if (sound) {
							driver.PlayOneShot (win);
							sound = false;
						}
						
				}
			
	}
}
