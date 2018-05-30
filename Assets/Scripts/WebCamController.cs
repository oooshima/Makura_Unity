//Planeを作成しアタッチ
//webカメラに繋げて、planeに表示。動く方向をsekigaisen.csに送る
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamController : MonoBehaviour {

	int width = 1920;
	int height = 1080;
	int fps = 30;
	float xp = 0;
	float yp = 0;
	float xi = 0;
	float yi = 0;
	float xd = 0;
	float yd = 0;
	float xe = 0;
	float ye = 0;
	float tani = 0;
	float tani2 = 0;
	public static int flag = 0;
	public static int flag2 = 0;
	GameObject refObj;
	GameObject refObjb;
	Texture2D texture;
	WebCamTexture webcamTexture;
	Color32[] colors = null;

	IEnumerator Init()
	{
		while (true)
		{
			if (webcamTexture.width > 16 && webcamTexture.height > 16)
			{
				colors = new Color32[webcamTexture.width * webcamTexture.height];
				texture = new Texture2D (webcamTexture.width, webcamTexture.height, TextureFormat.RGBA32, false);
				GetComponent<Renderer> ().material.mainTexture = texture;
				break;
			}
			yield return null;
		}
	}

	// Use this for initialization
	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		webcamTexture = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
		webcamTexture.Play();

		StartCoroutine (Init ());
	}

	// Update is called once per frame
	void Update () 
	{
		Debug.Log ("flag" + flag);
	/*	refObjb = GameObject.Find ("Player");
		//refObj = GameObject.Find("Canvas/Text");
		if (colors != null)
		{
			webcamTexture.GetPixels32 (colors);

			int width = webcamTexture.width;
			int height = webcamTexture.height;
			//Color32 rc = new Color32();

			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					Color32 c = colors [x + y * width];
					//byte gray = (byte)(0.1f * c.r + 0.7f * c.g + 0.2f * c.b);
					//rc.r = rc.g = rc.b = gray;
					//colors [x + y * width] = rc;
					float white = c.r  + c.g  + c.b;

					if (760 < white) {
						//refObj.GetComponent<ScoreText> ().score = "xに" + xp.ToString () + ",yに" + yp.ToString ();
						if (Input.GetKeyDown (KeyCode.S)) {
							if (flag2 == 0) {
								xi = width / 2;
								yi = y;
								flag = 1;
								//flag2 = 1;
							}

						}
						if(flag == 0){
							refObjb.GetComponent<Sekigaisen> ().x = 0;
							refObjb.GetComponent<Sekigaisen> ().y = 0;
				}
						if(flag ==1){
						xp = xi - x;
						yp = yi - y;
						tani = xp*xp + yp*yp;
						tani2 = Mathf.Sqrt (tani);
						xd = xp/tani2;
						yd = yp/tani2;
							xe = xd/1.8f;
							ye = yd/1.8f;
							Debug.Log ("xp:" + xp);
							Debug.Log ("yp:" + yp);
						refObjb.GetComponent<Sekigaisen> ().x = xe;
						refObjb.GetComponent<Sekigaisen> ().y = -ye;

						//refObj.GetComponent<ScoreText> ().score = white.ToString ();
						}

					}
					//}




				}
			}

			texture.SetPixels32 (colors);
			texture.Apply ();
		}*/
	}
}