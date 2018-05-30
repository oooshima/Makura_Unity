using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senario3 : MonoBehaviour {
	public GameObject makura;
	public GameObject taihou;
	public GameObject bakudan;
	public GameObject baikin;

	private GameObject Makura;
	private GameObject Taihou;
	private GameObject Bakudan;
	private GameObject Baikin;

	private bool bakudanflag = true;
	private float life = 3.0f;

	public static bool taihouflag = false;
	// Use this for initialization
	void Start () {
		Makura = Instantiate(makura);
		Makura.transform.parent = GameObject.Find("Canvas").transform;
		Makura.GetComponent<RectTransform>().anchoredPosition = new Vector3(-171.25f,0f,0f);
		Makura.GetComponent<RectTransform>().localScale = new Vector3(2.5f,2.0f,2.0f);
		Makura.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 11.48f);
	}
	
	// Update is called once per frame
	void Update () {
		if(WebcamCapture.start == true){
			Taihou = Instantiate(taihou);
			Taihou.transform.parent = GameObject.Find("Canvas").transform;
			Taihou.GetComponent<RectTransform>().localPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,-50.0f);
			Taihou.GetComponent<RectTransform>().localScale = new Vector3(1.3f,1.3f,1.3f);
			Taihou.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180f, 0);
			Destroy(Makura);
			WebcamCapture.start = false;
			taihouflag = true;
		}
		if(taihouflag == true){
			Taihou.GetComponent<RectTransform>().anchoredPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,0f);
			Taihou.GetComponent<RectTransform>().localScale *= WebcamCapture.Size; 
			Taihou.transform.Rotate(0, 0,(Taihou.GetComponent<RectTransform>().localRotation.z-WebcamCapture.theta));
		}
		if((DoSomething.diff_a0 > 0.5f && DoSomething.diff_a1 > 0.5f)||(DoSomething.diff_a2 > 0.5f && DoSomething.diff_a3 > 0.5f)){
			if(bakudanflag == true){
				BakudanInstance();
			}
			Debug.Log("Dooon");
		}else{
			bakudanflag = true;
		}
			life -= Time.deltaTime;
			if(life < 0){
			Baikin = Instantiate(baikin);
			Baikin.transform.parent = GameObject.Find("Canvas").transform;
			Baikin.GetComponent<RectTransform>().localPosition = new Vector3(Random.Range(250f,300f),Random.Range(-150f,150f),18.0f);
			Baikin.GetComponent<RectTransform>().localScale = new Vector3(1.0f,1.0f,1.0f);
			Baikin.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0f, 0);
			life = 6.0f;
			}
	}

	void BakudanInstance(){
			Bakudan = Instantiate(bakudan);
			Bakudan.transform.parent = GameObject.Find("Canvas").transform;
			Bakudan.GetComponent<RectTransform>().anchoredPosition = new Vector3(Taihou.GetComponent<RectTransform>().anchoredPosition.x,Taihou.GetComponent<RectTransform>().anchoredPosition.y,-50f);
			Bakudan.GetComponent<RectTransform>().localScale = new Vector3(1.0f,1.0f,1.0f);
			Bakudan.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0f, 0);
			bakudanflag = false;
	}
}
