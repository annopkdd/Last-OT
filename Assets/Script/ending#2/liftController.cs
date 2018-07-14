using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftController : MonoBehaviour {

		public GameObject lift_left;
		public GameObject lift_right;
		public GameObject ghost;
		public Rigidbody rigid;
		public Animator animator;
		public Animator animator_ghost;
		public AudioSource driver;
		public AudioClip win;
		//public Animator animator;
		public int inLift = 0;
	public bool sound = true;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
				// -29.56
				if (inLift == 0) { 
						if (lift_left.transform.position.x > -32.74) {
								lift_left.transform.position += new Vector3 (-0.05f, 0, 0);

						} // -26.13
						if (lift_right.transform.position.x < -22.87) {
								lift_right.transform.position += new Vector3 (0.05f, 0, 0);

						}
						if (lift_left.transform.position.x <= -32.74 && lift_right.transform.position.x >= -22.87) {
								inLift = 1;
						}
				}

		if (inLift == 1) {
						if (transform.position.y >= -3.8) {
							if (sound) {
								driver.PlayOneShot (win);
								sound = false;
							}
						}
						if (transform.position.y >= -0.9) {
								if (animator.GetInteger ("Direction")!=0 || (animator.GetInteger ("run_to_stand")!=0 )){
										animator.SetInteger ("stand_to_run", 0);
										animator.SetInteger ("Direction", 0);
										animator.SetInteger ("run_to_stand", 0);
										animator.SetInteger ("stand_to_run", 99);
								}
								inLift = 2;

						} else {
								Vector3 move = transform.position + (transform.up *0.05f);
								if (animator.GetInteger ("stand_to_run") != 2) {
										animator.SetInteger ("stand_to_run", 2);
								}
								animator.SetInteger ("Direction", 2);
								rigid.MovePosition (move);
						}

				}
				if (inLift == 2) {
						if(lift_left.transform.position.x < -29.56 ){
								lift_left.transform.position += new Vector3 (0.05f, 0, 0);

						} // -26.13
						if(lift_right.transform.position.x > -26.13 ){
								lift_right.transform.position += new Vector3 (-0.05f, 0, 0);

						}
						animator_ghost.SetBool ("isHunt", true);
						if (ghost.transform.position.y <= -4.8) {
								ghost.transform.position += new Vector3 (0, 0.4f, 0);	
						}

				}
			
	}
}
