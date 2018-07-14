using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerController : MonoBehaviour
{

    public Animator animator;
	public GameObject ghost;
	public GameObject cam;
	public Rigidbody rigid;
	public GameObject bg;
	public GameObject map;
	public int derection_now;
	private Vector3 distance;
	private float speed = 0.1f;
	private int  count=0;
	private Collider hiding_now;
	public bool hiding = false;
		public GameObject myitem;
		public GameObject backpack_ui;
		public GameObject battery_ui;
		public GameObject cord_ui;
		public GameObject dictionary_ui;
		public GameObject gloves_ui;
		public GameObject lighter_ui;
		public GameObject oil_ui;
		public GameObject plunger_ui;
		public GameObject spray_ui;
		public GameObject toiletpaper_ui;
		public GameObject tools_ui;
		public GameObject umbrella_ui;
		public GameObject water_ui;
		public GameObject cross_ui;
		public GameObject holywater_ui;

		private GameObject keeping1 = null;
		private GameObject keeping2 = null;
		private GameObject keeping3 = null;

		private GameObject slot1;
		private GameObject slot2;
		private GameObject slot3;

		public GameObject oil;
		public GameObject water;
		public GameObject backpack;
		public GameObject battery;
		public GameObject cord;
		public GameObject dictionary;
		public GameObject gloves;
		public GameObject lighter;
		public GameObject plunger;
		public GameObject spray;
		public GameObject tools;
		public GameObject umbrella;
		public GameObject toiletpaper;
		public GameObject cross;


		public GameObject ending1_area;
		public GameObject ending2_area;
		public GameObject ending3_area;
		public GameObject ending5_area;
		private bool ending_area_open = false;
		public GameObject scoll;
		public GameObject howToPlay;
		public bool NotPlayYet = true;
		public string next_scene;



		private int countItems = 0;



		void Start()
    {
			distance = cam.transform.position-transform.position;
			
			bg.transform.position += new Vector3 (0, 0, -4);
				slot1 = null;
				slot2 = null;
				slot3 = null;
    }
				
    void Update()
    {
		if (NotPlayYet) {
			if (Input.GetKeyDown ("space")) {
				howToPlay.SetActive (false);
				NotPlayYet = false;
			} else {
				howToPlay.SetActive (true);
			}

		} else {
			float v = Input.GetAxis ("Vertical");
			float h = Input.GetAxis ("Horizontal");
			if (Input.GetKeyDown ("m") && !map.GetComponent<Camera> ().enabled) {
				map.GetComponent<Camera> ().enabled = true;
				scoll.SetActive (true);
				bg.SetActive (false);

				oil.GetComponent<Renderer> ().enabled = false;
				water.GetComponent<Renderer> ().enabled = false;
				backpack.GetComponent<Renderer> ().enabled = false;
				battery.GetComponent<Renderer> ().enabled = false;
				cord.GetComponent<Renderer> ().enabled = false;
				dictionary.GetComponent<Renderer> ().enabled = false;
				gloves.GetComponent<Renderer> ().enabled = false;
				lighter.GetComponent<Renderer> ().enabled = false;
				plunger.GetComponent<Renderer> ().enabled = false;
				spray.GetComponent<Renderer> ().enabled = false;
				tools.GetComponent<Renderer> ().enabled = false;
				umbrella.GetComponent<Renderer> ().enabled = false;
				toiletpaper.GetComponent<Renderer> ().enabled = false;
				cross.GetComponent<Renderer> ().enabled = false;


				
			} else if (Input.GetKeyDown ("m") && map.GetComponent<Camera> ().enabled) {
				map.GetComponent<Camera> ().enabled = false;
				scoll.SetActive (false);
				bg.SetActive (true);

				oil.GetComponent<Renderer> ().enabled = true;
				water.GetComponent<Renderer> ().enabled = true;
				backpack.GetComponent<Renderer> ().enabled = true;
				battery.GetComponent<Renderer> ().enabled = true;
				cord.GetComponent<Renderer> ().enabled = true;
				dictionary.GetComponent<Renderer> ().enabled = true;
				gloves.GetComponent<Renderer> ().enabled = true;
				lighter.GetComponent<Renderer> ().enabled = true;
				plunger.GetComponent<Renderer> ().enabled = true;
				spray.GetComponent<Renderer> ().enabled = true;
				tools.GetComponent<Renderer> ().enabled = true;
				umbrella.GetComponent<Renderer> ().enabled = true;
				toiletpaper.GetComponent<Renderer> ().enabled = true;
				cross.GetComponent<Renderer> ().enabled = true;
			}	
			Vector3 move = transform.position;// + (transform.forward * v * speed);
		
			if (Input.GetKeyDown ("c")) {
				if (keeping3 != null) {
					keeping3.GetComponent<Renderer> ().enabled = true;
					keeping3.transform.position = transform.position;
					keeping3 = null;
					slot3.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-200, -30, 0);
					slot3 = null;
					countItems--;
				} else if (keeping2 != null) {
					keeping2.GetComponent<Renderer> ().enabled = true;
					keeping2.transform.position = transform.position;
					slot2.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-200, -30, 0);
					keeping2 = null;
					slot2 = null;
					countItems--;
				} else if (keeping1 != null) {
					keeping1.GetComponent<Renderer> ().enabled = true;
					keeping1.transform.position = transform.position;
					slot1.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-200, -30, 0);
					keeping1 = null;
					slot1 = null;
					countItems = 0;
				}
			}
	
			checkItem ();
			if (v != 0 || h != 0) {
				animator.SetInteger ("run_to_stand", 99);
				if (v > 0) {
					derection_now = 2;
					animator.SetInteger ("stand_to_run", 2);
					animator.SetInteger ("Direction", 2);
					move = transform.position + (transform.up * v * speed);
				} else if (v < 0) {
					derection_now = 0;
					animator.SetInteger ("Direction", 0);
					animator.SetInteger ("stand_to_run", 0);
					move = transform.position + (transform.up * v * speed);
				
				} else if (h > 0) {
					derection_now = 1;
					animator.SetInteger ("stand_to_run", 1);
					animator.SetInteger ("Direction", 1);
					move = transform.position + (transform.right * h * speed);
				} else if (h < 0) {
					derection_now = 3;
					animator.SetInteger ("stand_to_run", 3);
					animator.SetInteger ("Direction", 3);
					move = transform.position + (transform.right * h * speed);
				}
			} else {
				animator.SetInteger ("stand_to_run", 99);
				if (derection_now == 0) {
					animator.SetInteger ("run_to_stand", 0);		
				} else if (derection_now == 1) {
					animator.SetInteger ("run_to_stand", 1);
				} else if (derection_now == 2) {
					animator.SetInteger ("run_to_stand", 2);
				} else if (derection_now == 3) {
					animator.SetInteger ("run_to_stand", 3);
				}
			
			}
			if (Input.GetKeyDown ("x") && hiding) {
				hiding = false;
				GetComponent<Collider> ().enabled = true;
				GetComponent<Renderer> ().enabled = true;
				hiding = false;
				hiding_now.GetComponent<Renderer> ().enabled = false;
				hiding_now.transform.position = new Vector3(hiding_now.transform.position.x, hiding_now.transform.position.y, 0.1f);
			}

			if (!hiding) {
				rigid.MovePosition (move);
				cam.transform.position = transform.position + distance;
				bg.transform.position = transform.position;
				bg.transform.position = bg.transform.position + new Vector3 (-0.95f, 0, -4f);
			}
			count++;
		}
    }

		void OnTriggerStay(Collider  other){
				if (other.tag == "items" && Input.GetKeyDown ("space") && countItems < 3) {
						if (other.name.Equals ("backpack")) {
								myitem = backpack_ui;
						} else if (other.name.Equals ("battery")) {
								myitem = battery_ui;
						} else if (other.name.Equals ("cord")) {
								myitem = cord_ui;
						}
						else if (other.name.Equals ("dictionary")) {
								myitem = dictionary_ui;
						}
						else if (other.name.Equals ("gloves")) {
								myitem = gloves_ui;
						}
						else if (other.name.Equals ("lighter")) {
								myitem = lighter_ui;
						}
						else if (other.name.Equals ("oil")) {
								myitem = oil_ui;
						}
						else if (other.name.Equals ("plunger")) {
								myitem = plunger_ui;
						}
						else if (other.name.Equals ("spray")) {
								
								myitem = spray_ui;
						}
						else if (other.name.Equals ("toilet-paper")) {
								myitem = toiletpaper_ui;
						}
						else if (other.name.Equals ("tools")) {
								myitem = tools_ui;
						}
						else if (other.name.Equals ("umbrella")) {
								myitem = umbrella_ui;
						}
						else if (other.name.Equals ("water")) {
								myitem = water_ui;
						}
						else if (other.name.Equals ("cross")) {
								myitem = cross_ui;
						}
						else if (other.name.Equals ("Holy-water")) {
								myitem = holywater_ui;
						}
						else if (other.name.Equals ("tools")) {
								myitem = tools;
						}
						if (countItems == 0) {
								slot1 = myitem;
								keeping1 = other.gameObject;
								myitem.GetComponent<RectTransform> ().anchoredPosition = new Vector3(-175,41,0);
								countItems++;
						}
						else if (countItems == 1) {
								slot2 = myitem;
								keeping2 = other.gameObject;
								myitem.GetComponent<RectTransform> ().anchoredPosition = new Vector3(-120,41,0);
								countItems++;
						}
						else if (countItems == 2) {
								slot3 = myitem;
								keeping3 = other.gameObject;
								myitem.GetComponent<RectTransform> ().anchoredPosition = new Vector3(-65,41,0);
								countItems = 3;
						}
						other.GetComponent<Renderer> ().enabled = false;
						other.transform.position += new Vector3 (0, 0, 10);
				}
				if(other.gameObject.name == "area") {
						if (Input.GetKeyDown("z") && !hiding) {
							
								hiding = true;
								
								GetComponent<Collider> ().enabled=false;
								GetComponent<Renderer> ().enabled=false;
								other.GetComponent<Renderer> ().enabled=true;
							
								var otherPosn = other.transform.position;
								other.transform.position = new Vector3(otherPosn.x, otherPosn.y, 3f);
									
								hiding_now = other;

								count++;
						} 
				}
				if (ending_area_open) {
						if (other.name == "ending1-area") {
								SceneManager.LoadScene ("Ending#1");
						}
						else if (other.name == "ending2-area") {
								SceneManager.LoadScene ("Ending#2");
						}
						else if (other.name == "ending3-area") {
								SceneManager.LoadScene ("Ending#3");
						}
						else if (other.name == "ending5-area") {
								SceneManager.LoadScene ("Ending#5");
						}

				}

		}
		public bool isIn(string name){
				if (slot1 != null && slot2 != null && slot3 != null) {
						if (slot1.name == name || slot2.name == name || slot3.name == name) {
								return true;
						} else {
								return false;
						}
				} else {
						return false;
				}


		}

		public void checkItem(){
				
				if (isIn ("oil") && isIn ("lighter") && isIn ("dictionary")) {
						setEndingAreaFalse ();
						ending5_area.SetActive (true);
						ending_area_open = true;
				} else if (isIn ("cross") && isIn ("Holy-Water") && isIn ("dictionary")) {
						float diff_player_ghost = Mathf.Sqrt (Mathf.Pow (Mathf.Abs (transform.position.x -ghost.transform.position.x), 2) + Mathf.Pow (Mathf.Abs (transform.position.y - ghost.transform.position.y), 2));
						if (diff_player_ghost <= 10) {
								SceneManager.LoadScene ("Ending#4");
						}
				} else if (isIn ("plunger") && isIn ("toilet-paper") && isIn ("spray")) {
						setEndingAreaFalse ();
						ending3_area.SetActive (true);
						ending_area_open = true;
				} else if (isIn ("tools") && isIn ("battery") && isIn ("gloves")) {
						setEndingAreaFalse ();
						ending2_area.SetActive (true);
						ending_area_open = true;
				} else if (isIn ("backpack") && isIn ("umbrella") && isIn ("cord")) {
						setEndingAreaFalse ();
						ending1_area.SetActive (true);
						ending_area_open = true;
				} else {
						setEndingAreaFalse ();
						ending_area_open = false;
				}		
				
		}

		public void setEndingAreaFalse(){
				ending1_area.SetActive (false);
				ending2_area.SetActive (false);
				ending3_area.SetActive (false);
				ending5_area.SetActive (false);
		}

}
