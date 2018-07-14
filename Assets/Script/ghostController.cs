using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ghostController : MonoBehaviour {
		public Animator ghost;
		public Animator player;
		public Rigidbody rigid;
		public Animator anim;
		float speedX = 0;
		float speedY = 0;
		float speedZ = 0;
		int state;
		private float posX1;
		private float posX2;
		private float posY1;
		private float posY2;
		private float count=0;
		private Vector3 move;
		void Start() {
				state = 1;
				state1 ();
				speedX = 0.075f;
				ghost.GetComponent<Renderer> ().enabled=false;
		}


		void Update () {
				float diff_player_ghost = Mathf.Sqrt (Mathf.Pow (Mathf.Abs (player.transform.position.x - ghost.transform.position.x), 2) + Mathf.Pow (Mathf.Abs (player.transform.position.y - ghost.transform.position.y), 2));
				if(   diff_player_ghost <= 10 && !player.GetComponent<playerController>().hiding) {
						if (diff_player_ghost <= 6) {
								ghost.GetComponent<Renderer> ().enabled = true;
								if (diff_player_ghost <= 0.5) {
										SceneManager.LoadScene ("Dead");
								}
						} else {
								ghost.GetComponent<Renderer> ().enabled = false;

						}
						anim.SetBool ("isHunt", true);
						float difPlayerX = player.transform.position.x - ghost.transform.position.x;
						float difPlayerY = player.transform.position.y - ghost.transform.position.y;
						float difX = difPlayerX;
						float dify = difPlayerY;
						speedX = 0.065f * (int)(difX / Mathf.Abs (difX));
						speedY = 0.065f * (int)(dify / Mathf.Abs (dify));

				}
				else  {
						anim.SetBool ("isHunt", false);
						if ( ((ghost.transform.position.x > posX2+0.5 || ghost.transform.position.x < posX1-0.5) || (ghost.transform.position.y > posY2+0.7 || ghost.transform.position.y < posY1-0.7) ) ){ 
								float difPointX = (float)(posX1 - ghost.transform.position.x);
								float difPointY = (float)(posY1 - ghost.transform.position.y);
								float difX = difPointX;
								float dify = difPointY;
								speedX = 0.075f * (difX / (float)Mathf.Abs (difX));
								speedY = 0.075f * (dify / Mathf.Abs (dify));

						} else {
								if (count > 700) {
										randomState ();								
										anim.SetBool ("isWarp", true);
										count = 0;
								}
								else {
										if (posX1 != posX2) {
												speedY = 0;
												if (ghost.transform.position.x >= posX2) {

														speedX = -0.075f;
												}
												if (ghost.transform.position.x <= posX1) {
														speedX = 0.075f;
												}
										}
										if (posY1 != posY2) {
												speedX = 0;
												if (ghost.transform.position.y >= posY2) {

														speedY = -0.075f;
												}
												if (ghost.transform.position.y <= posY1) {
														speedY = 0.075f;
												}
										}
								}

						}				

				}
				if( !anim.GetBool("isWarp")){
						if (player.transform.position.x < ghost.transform.position.x || Mathf.Abs(player.transform.position.x-ghost.transform.position.x)<0.5 ) {
								ghost.transform.localEulerAngles = new Vector3(0,180,0);
							
						} else{
								ghost.transform.localEulerAngles = new Vector3(0,0,0);
						}
					move = new Vector3(speedX, speedY, speedZ);
					ghost.transform.position = ghost.transform.position + move;
						count += 1;
				}
		}

		public void state1(){
				speedY = 0;
				posX1 = -43f;
				posX2 = 2.4f;
				posY1 = 19.6f;
				posY2 = 19.6f;
		}

		public void state2(){
				speedY = 0;
				posX1 = -43f;
				posX2 = -6.5f;
				posY1 = -6.9f;
				posY2 = -6.9f;
		}

		public void state3(){
				speedY = 0;
				posX1 = 8f;
				posX2 = 30f;
				posY1 = -6.9f;
				posY2 = -6.9f;
		}

		public void state4(){
				speedX = 0;
				posX1 = 1.5f;
				posX2 = 1.5f;
				posY1 = -7f;
				posY2 = 20f;
		}

		public void state5(){
				speedX = 0;
				posX1 = 10.5f;
				posX2 = 10.5f;
				posY1 = 11.8f;
				posY2 = 31.6f;
		}
		public void state6(){
				speedY = 0;
				posX1 = 10.5f;
				posX2 = 32.6f;
				posY1 = 12f;
				posY2 = 12f;
		}
		public void randomState(){
				int laststage = state;
				float x = Random.Range (1, 6);
				while ((int)x == laststage) {
						x = Random.Range (1, 6);
				}
				if (x == 1) {
						state1 ();
				}
				if (x == 2) {
						state2 ();
				}
				if (x == 3) {
						state3 ();
				}
				if (x == 4) {
						state4 ();
				}
				if (x == 5) {
						state5 ();
				}
				if (x == 6) {
						state6 ();
				}
		}
		public void warp()
		{	
				ghost.transform.position = new Vector3(posX1,posY1,0);
				anim.SetBool ("isWarping", true);

		}
		public void false_warp(){
				anim.SetBool ("isWarp", false);
				anim.SetBool ("isWarping", false);
		}
	


}

