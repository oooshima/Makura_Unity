using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bakuhatu : MonoBehaviour {
	private Image image;
	private AudioSource bakuhatu_sound;
	// Use this for initialization
	void Start () {
		image = this.gameObject.GetComponent<Image>();
		bakuhatu_sound = this.gameObject.GetComponent<AudioSource>();
		bakuhatu_sound.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
		var color = image.color;
		color.a -= 0.01f;
		image.color = color;
		this.GetComponent<RectTransform>().localScale -= new Vector3(0.01f,0.01f,0.0f);
		Destroy(this.gameObject,2.0f);
	}
}
