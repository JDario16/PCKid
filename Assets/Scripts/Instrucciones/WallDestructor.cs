﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
            GameObject.Find("Pacman").GetComponent<ControlCharacter>().StopAllCoroutines();
		}
	}
}