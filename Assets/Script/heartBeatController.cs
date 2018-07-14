using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class heartBeatController : MonoBehaviour {

	public AudioSource heartBeat;
		public Animator ghost;
		public Animator player;
		public AudioClip scream;
		public AudioSource step;
		private bool scared=true;
		private bool stepHold = false;

	// Use this for initialization
	void Start () {
				
				heartBeat.transform.position = ghost.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
				heartBeat.transform.position = ghost.transform.position;
				float posDif;
				posDif = Mathf.Sqrt (Mathf.Pow (Mathf.Abs (player.transform.position.x - ghost.transform.position.x), 2) + Mathf.Pow (Mathf.Abs (player.transform.position.y - ghost.transform.position.y), 2));
				float volumnPer;
				if (posDif > 16f) {
						posDif = 16f;
				}
				volumnPer = ((16f - posDif) / 16f);
				heartBeat.volume = volumnPer;
				heartBeat.pitch = 1 + volumnPer;
				if (posDif < 7f && scared) {
						heartBeat.PlayOneShot (scream);
						scared = false;
				} else if(posDif>9f){
						scared = true;
				}
				if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) {
						if (stepHold != true) {
								step.Play ();
								stepHold = true;
						}
						step.loop = true;
						step.mute = false;
				} else {
						stepHold = false;
						step.loop = false;
						step.mute = true;
				}
	}
}
