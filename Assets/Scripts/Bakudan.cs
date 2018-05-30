using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakudan : MonoBehaviour {
	public GameObject bakuhatu;
	private GameObject Bakuhatu;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<RectTransform>().localPosition += new Vector3(3f,0,0);
		if (this.GetComponent<RectTransform>().localRotation.z <= 360) {
      	this.transform.Rotate (0, 0, 2);
    	}
		Destroy(this.gameObject,5.0f);
	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "baikin"){
			Bakuhatu = Instantiate(bakuhatu);
			Bakuhatu.transform.parent = GameObject.Find("Canvas").transform;
			Bakuhatu.GetComponent<RectTransform>().anchoredPosition = new Vector3(this.gameObject.GetComponent<RectTransform>().anchoredPosition.x+15.0f,this.gameObject.GetComponent<RectTransform>().anchoredPosition.y,0f);
			Bakuhatu.GetComponent<RectTransform>().localScale = new Vector3(3.0f,3.0f,1.0f);
			Bakuhatu.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0f, 0);
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}
	}
}
