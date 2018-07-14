using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeadController : MonoBehaviour {

		private int state =0;
		public Renderer renderer;

	void Update () {
				if (state == 0) {
						transform.RotateAround (new Vector3 (7.8f, -9.89f, 0), Vector3.forward, 0.25f);
						if (transform.rotation.z  > 0.075) {
								state = 1;
						}
				}
				if(state == 1 ){
						transform.RotateAround (new Vector3 (7.8f, -9.89f, 0), Vector3.forward, -0.25f);
						if(transform.rotation.z < -0.08){
								state = 0;
						}
				}	
	}
}
