using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player5Controller : MonoBehaviour {
		public GameObject fire;
		public GameObject lighter;
		public GameObject fuel;
		public GameObject chair;
		public GameObject ghost;
		public Animator anim;
		public Animator animGhost;
		public AudioSource driver;
		public AudioClip thw, bomb;
		private int state = 0;
		private int count = 0;
		public AudioClip win;
		private int state_sound = 1;
		public bool sound = true;
	// Use this for initialization
	void Start () {
				anim.enabled = false;
				fire.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
				if (state == 0) {
						if (fuel.transform.position.x > -40.96) {
								if (state_sound==1) {
									driver.PlayOneShot (thw);
									state_sound = 2;
								}	
								fuel.transform.position += new Vector3 (-0.1f, 0.1f, 0);
								fuel.transform.Rotate (new Vector3 (0, 0, -5f), Space.World);
						} else if (fuel.transform.position.x <= -40.96 && fuel.transform.position.x >= -44.56) {
								fuel.transform.position += new Vector3 (-0.1f, -0.05f, 0);
								fuel.transform.Rotate (new Vector3 (0, 0, -5f), Space.World);
						} else {
								state = 1;
						}
				} else if (state == 1) {
						if (lighter.transform.position.x > -40.96) {
							if (state_sound==2) {
								driver.PlayOneShot (thw);
								state_sound = 3;
							}	
							lighter.transform.position += new Vector3 (-0.1f, 0.1f, 0);
							lighter.transform.Rotate (new Vector3 (0, 0, -10f), Space.World);
						} else if (lighter.transform.position.x <= -40.96 && lighter.transform.position.x >= -44.56) {
								lighter.transform.position += new Vector3 (-0.1f, -0.05f, 0);
								lighter.transform.Rotate (new Vector3 (0, 0, 10f), Space.World);
						} else {
								state = 2;
						}
				} else if (state == 2) {
						if (count >= 40) {
							if (sound) {
								driver.PlayOneShot (win);
								sound = false;
							}
						}
						if (count >= 100) {
									if (state_sound==3) {
											driver.PlayOneShot (bomb);
											state_sound = 4;
									}	
									fire.SetActive (true);
									if (fire.transform.localScale.x <= 1.7) {
											fire.transform.localScale += new Vector3 (0.01f, 0.01f, 0.01f);
									} else {
											state = 3;
											count = 0;
									}	
						}
						count++;
				} else if (state == 3) {
						chair.SetActive (false);
						if (fire.transform.localScale.x >= 0) {
								fire.transform.localScale += new Vector3 (-0.01f, -0.01f, -0.01f);
						} else {
								fire.SetActive (false);
								state = 4;
						}
				} else if (state == 4) {
						if (ghost.transform.position.x >= -40) {
								ghost.transform.position += new Vector3 (-0.1f, 0, 0);
						}

						if (ghost.transform.position.x <= -33.21) {
								if (state_sound==4) {
									driver.PlayOneShot (bomb);
									state_sound = 5;
								}
								fire.SetActive (true);
								if (fire.transform.localScale.x <= 1) {
										fire.transform.localScale += new Vector3 (0.01f, 0.01f, 0.01f);
								}
						}
						transform.position += new Vector3 (-0.1f, 0, 0);
						anim.SetInteger ("stand_to_run", 3);
						anim.SetInteger ("Direction", 3);
						anim.enabled = true;
						animGhost.SetBool ("isHunt", true);
				}
	}
}
