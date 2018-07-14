using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player3Controller : MonoBehaviour {
	private int count =0;
	public Animator animator_ghost;
	public GameObject ghost;
	private bool isPlayed = false;
	public AudioSource pipeDrive;
	public AudioClip win;
	public bool sound = true;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
				transform.localEulerAngles = new Vector3(0,360,0);
				if (count > 100) {
						if (!isPlayed) {
							isPlayed = true;
							pipeDrive.Play ();
						}
						if (transform.position.y > 8.8) {
								transform.position += new Vector3 (0, -0.01f, 0);
								if (ghost.transform.position.y >= 9.55) {
									if (ghost.transform.position.y <= 14.5 && sound) {
										pipeDrive.PlayOneShot (win);
										sound = false;
									}
									animator_ghost.SetBool ("isHunt", true);
									ghost.transform.position += new Vector3 (0, -0.05f, 0);	
								}
						}
				}
				count++;
	}
}
