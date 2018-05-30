using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanchTest : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (SerialTest.r < 994) {
			anim.SetBool ("flag", true);
		} else {
			anim.SetBool ("flag", false);
		}
	}
}
