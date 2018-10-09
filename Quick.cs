using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Unit.moving) {
			GetComponent<Animator> ().SetBool ("isRunning", true);
			
		} else {
			GetComponent<Animator>().SetBool("AttackFlag", false);
		}

	}
}
