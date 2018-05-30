using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DemoMovie: MonoBehaviour {

	public GameObject kuma;
	public static bool flag = false;
	private GameObject Kuma;
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(WebcamCapture.start == true){
		Kuma = Instantiate(kuma);
		Kuma.transform.parent = GameObject.Find("Canvas").transform;
		Kuma.GetComponent<RectTransform>().localPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,0f);
		Kuma.GetComponent<RectTransform>().localScale = new Vector3(1.5f,2.0f,1.0f);
		Kuma.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
		flag = true;
		WebcamCapture.start = false;
		}
	if(flag == true){
		Debug.Log("aaa");
		Kuma.GetComponent<RectTransform>().anchoredPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,0f);
		Kuma.GetComponent<RectTransform>().localScale *= WebcamCapture.Size;
		Kuma.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180f-DoSomething.diff_acc_angle_y, Kuma.GetComponent<RectTransform>().localRotation.z-WebcamCapture.theta);
		}
	}
}
