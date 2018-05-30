using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unkTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (SerialTest.r < -75) {
			transform.position += new Vector3 (0.1f, 0, 0);
		}
		if (SerialTest.r > 85) {
			transform.position += new Vector3 (-0.1f, 0, 0);
		}
	}
}
