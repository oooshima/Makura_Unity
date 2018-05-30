using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShizukuController : MonoBehaviour {

	public AudioClip waterclip;
	private AudioSource watersound;


	// Use this for initialization
	void Start () {
		watersound = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
		this.GetComponent<RectTransform>().localPosition += new Vector3(0,-3f,0);
		if(this.GetComponent<RectTransform>().anchoredPosition.y < -400f||Senario2.Shizukuflag == false){
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "pot"){
			Senario2.watercount += 1;
			watersound.clip = waterclip;
			watersound.Play();
			Destroy(this.gameObject,0.5f);
		}
	}
}
