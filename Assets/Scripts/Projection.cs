using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projection : MonoBehaviour {

public GameObject Point;
private GameObject point;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)){
			point = Instantiate(Point);
			point.transform.parent = GameObject.Find("Canvas").transform;
			point.GetComponent<RectTransform>().anchoredPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,0);
			point.GetComponent<RectTransform>().localScale = new Vector3(0.5f,0.5f,0.5f);
			point.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
			}
	}
}
