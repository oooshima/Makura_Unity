using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Senario1 : MonoBehaviour {

	public GameObject kuma_ishi;
	public GameObject kuma;
	public GameObject makura;
	public GameObject mori;
	public GameObject back;
	public GameObject flower;
	public GameObject kirakira;

	private GameObject Kuma_ishi;
	private GameObject Kuma;
	private GameObject Makura;
	private Image kuma_image;
	private Image kirakira_image;

	private float _Step = 0.05f;

	private float kyori;
	
	public static bool walkflag = false;
	public static bool kumaflag = false;
	private bool kirakiraflag = false;
	private bool kumatrueflag = false;

	// Use this for initialization
	void Start () {
		Makura = Instantiate(makura);
		Makura.transform.parent = GameObject.Find("Canvas").transform;
		Makura.GetComponent<RectTransform>().anchoredPosition = new Vector3(-171.25f,0f,0f);
		Makura.GetComponent<RectTransform>().localScale = new Vector3(2.5f,2.0f,2.0f);
		Makura.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 120f);
	}
	
	// Update is called once per frame
	void Update () {
		if(WebcamCapture.start == true){
			mori.SetActive (true);
			back.SetActive (false);
			Kuma_ishi = Instantiate(kuma_ishi);
			Kuma_ishi.transform.parent = GameObject.Find("Canvas").transform;
			Kuma_ishi.GetComponent<RectTransform>().localPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,0f);
			Kuma_ishi.GetComponent<RectTransform>().localScale = new Vector3(1.0f,1.5f,1.0f);
			Kuma_ishi.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180f, 0);
			Destroy(Makura);
			WebcamCapture.start = false;
			kumaflag = true;
		}
		if(kumaflag == true){
			Kuma_ishi.GetComponent<RectTransform>().anchoredPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,0f);
			Kuma_ishi.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180f-Mathf.Abs(DoSomething.diff_acc_angle_y), 0);
			Kuma_ishi.GetComponent<RectTransform>().localScale *= WebcamCapture.Size; 
			}
		if(kumatrueflag == true){
			Kuma.GetComponent<RectTransform>().anchoredPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,0f);
			Kuma.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180f-Mathf.Abs(DoSomething.diff_acc_angle_y), 0);
			Kuma.GetComponent<RectTransform>().localScale *= WebcamCapture.Size; 
		}
		if(Input.GetKeyDown(KeyCode.Z)){//ここを枕が持ち上げられたら…とかに直す
			walkflag = true;
		}
		if(walkflag == true){
			if(flower.GetComponent<RectTransform>().anchoredPosition.x > 330f){
				flower.GetComponent<RectTransform>().localPosition -= new Vector3(Time.time * 0.1f,0f,0f);
			}else{
				walkflag = false;
				kirakiraflag = true;
			}
		}

		kyori = Vector2.Distance(new Vector2(Kuma_ishi.GetComponent<RectTransform>().localPosition.x,Kuma_ishi.GetComponent<RectTransform>().localPosition.y),new Vector2(flower.GetComponent<RectTransform>().localPosition.x,flower.GetComponent<RectTransform>().localPosition.y));
		Debug.Log("kyori = "+kyori);

		if(kyori < 35f){
			Debug.Log("oooooooo");
			if(kirakiraflag == true){
			Kuma = Instantiate(kuma);
			kuma_image = Kuma.gameObject.GetComponent<Image>();
			Kuma.transform.parent = GameObject.Find("Canvas").transform;
			Kuma.GetComponent<RectTransform>().localPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,0f);
			Kuma.GetComponent<RectTransform>().localScale = new Vector3(1.0f,1.5f,1.0f);
			Kuma.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180f, 0);
			kumatrueflag = true;
			var color = kuma_image.color;
			color.a = 0.0f;
			kuma_image.color = color;
			kirakiraflag = false;
			}
			kirakira_image = kirakira.gameObject.GetComponent<Image>();

			var color_k = kirakira_image.color;
			if (color_k.a < 0 || color_k.a > 1){
            _Step = _Step * -1;
        	}
			color_k.a += _Step;
			kirakira_image.color = color_k;
			var color2 = kuma_image.color;
			color2.a += 0.005f;
			kuma_image.color = color2;
			if(color2.a > 0.9f){
				color_k.a -= 0.05f;
				kirakira_image.color = color_k;
			}
		}
	}
}
