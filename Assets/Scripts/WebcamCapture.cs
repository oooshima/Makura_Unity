using UnityEngine;
using System.Collections;

public class WebcamCapture : MonoBehaviour {

	//このクラスをウェブカメラの映像をテクスチャとして貼り付けるオブジェクトに適用する

	private WebCamTexture webcamtex;

	int width = 640;
	int height = 480;
	int fps = 30;
	int count = 0;
	Vector2 pos1;
	Vector2 pos2;
	Vector2 pos3;
	Vector2 newpos;
	Vector2 genten = new Vector2(0,0);
	Vector2 point;
	Vector2 prepoint;
	Vector2 cp;
	Vector2 cq;
	float gaiseki;
	float naiseki;
	public static float theta;

	float kyori1;
	float kyori2;
	float kyori3;
	public static float centerx;
	public static float centery;
	public static Vector2 Center;
	public static bool start = false;

	float side01;
	float side02;
	float side23;
	float side13;
	float dis0;
	float dis1;
	float dis2;
	float dis3;
	float Min;
	float preMin;
	public static float Size;
	bool pointflag = true;
	


	Color32[] colors = null;
	Texture2D texture;
	Vector2[] sekigaisen = new Vector2[4];

	// Use this for initialization
	void Start()
	{

		WebCamDevice[] devices = WebCamTexture.devices;
		webcamtex = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
		webcamtex.Play();
		Renderer _renderer = GetComponent<Renderer>();  //Planeオブジェクトのレンダラ
		_renderer.material.mainTexture = webcamtex;    //mainTextureにWebCamTextureを指定
		
		colors = new Color32[this.width * this.height];
		texture = new Texture2D (this.width, this.height, TextureFormat.RGBA32, false);
	
	}

IEnumerator Tyousa(){
	
		if (colors != null)
		{
			webcamtex.GetPixels32 (colors);
	
			for (int x = 0; x < this.width; x++)
			{
				for (int y = 0; y < this.height; y++)
				{
					Color32 c = colors [x + y * width];
					float white = c.r  + c.g  + c.b;
			
					if (500 < white) {
						if(count < 4){
							if(count == 0){
								Kiroku(x,y);
							}

							if(count == 1){
									newpos = new Vector2(x,y);
									pos1 = sekigaisen[0];
									kyori1= Vector2.Distance(pos1,newpos);
								if(kyori1 > 100.0f){
									Kiroku((int)pos1.x,y);
							}
						}

							if(count == 2){
									newpos = new Vector2(x,y);
									pos2 = sekigaisen[1];
									kyori1= Vector2.Distance(pos1,newpos);
									kyori2= Vector2.Distance(pos2,newpos);
								if(kyori1 > 100.0f && kyori2 > 100.0f){
									Kiroku(x,(int)pos1.y);
									}
						}

						if(count == 3){
									newpos = new Vector2(x,y);
									pos3 = sekigaisen[2];
									kyori1= Vector2.Distance(pos1,newpos);
									kyori2= Vector2.Distance(pos2,newpos);
									kyori3= Vector2.Distance(pos3,newpos);
								if(kyori1 > 50.0f && kyori2 > 50.0f && kyori3 > 50.0f){
									Kiroku((int)pos3.x,(int)pos2.y);
									}
						}


					}
				}
			}
		}
			texture.SetPixels32 (colors);
			texture.Apply ();
			}
			Debug.Log("0:"+sekigaisen[0].x+","+sekigaisen[0].y);
			Debug.Log("1:"+sekigaisen[1].x+","+sekigaisen[1].y);
			Debug.Log("2:"+sekigaisen[2].x+","+sekigaisen[2].y);
			Debug.Log("3:"+sekigaisen[3].x+","+sekigaisen[3].y);
			Keisan();
			Sides();
			yield return null;
		}

	void Kiroku(int x,int y){
		sekigaisen[count] = new Vector2(x,y);
		count++;
	}

	void Keisan(){//中点の計算
		centerx = (sekigaisen[0].x + sekigaisen[1].x + sekigaisen[2].x + sekigaisen[3].x)/4;
		centery = (sekigaisen[0].y + sekigaisen[1].y + sekigaisen[2].y + sekigaisen[3].y)/4;
		Center = new Vector2(centerx,centery);
		//Debug.Log("center:"+Center);
	}

	


	void Sides(){
		side01 = Vector2.Distance(sekigaisen[0],sekigaisen[1]);
		side02 = Vector2.Distance(sekigaisen[0],sekigaisen[2]);
		side23 = Vector2.Distance(sekigaisen[2],sekigaisen[3]);
		side13 = Vector2.Distance(sekigaisen[1],sekigaisen[3]);
		dis0 = Vector2.Distance(sekigaisen[0],genten);
		dis1 = Vector2.Distance(sekigaisen[1],genten);
		dis2 = Vector2.Distance(sekigaisen[2],genten);
		dis3 = Vector2.Distance(sekigaisen[3],genten);

		Min = Mathf.Min(side01,side02,side23,side13);
		if(Min == 0){
			Min = preMin;
		}
		Size = Min/preMin;
		
		if(Min == side01){
			if(dis0 > dis1){
				point = sekigaisen[1];
			}else{
				point = sekigaisen[0];
			}
		}
		if(Min == side02){
			if(dis0 > dis2){
				point = sekigaisen[2];
			}else{
				point = sekigaisen[0];
			}
		}
		if(Min == side23){
			if(dis2 > dis3){
				point = sekigaisen[3];
			}else{
				point = sekigaisen[2];
			}
		}
		if(Min == side13){
			if(dis1 > dis3){
				point = sekigaisen[3];
			}else{
				point = sekigaisen[1];
			}
		}

		cp = new Vector2(point.x-genten.x,point.y-genten.y);
		cq = new Vector2(prepoint.x-genten.x,prepoint.y-genten.y);

		gaiseki = cp.x * cq.y - cp.y * cq.x;
		naiseki = cp.x * cq.x + cp.y * cq.y;

		theta = Mathf.Atan(gaiseki/naiseki)* Mathf.Rad2Deg;

	/*if(theta > 90f){
		theta = theta - 27f;
	}if(theta < -90f){
		theta = theta + 27f;
	}*/

	if(prepoint.x == 0 && prepoint.y == 0){
		prepoint = point;
	}
		preMin = Min;
		/*Debug.Log("side01:"+side01);
		Debug.Log("side02:"+side02);
		Debug.Log("side23:"+side23);
		Debug.Log("side13:"+side13);
		Debug.Log("Min:"+Min);*/
		//Debug.Log("Slope"+Slope);
		//Debug.Log("diffSlope"+diffSlope);
		Debug.Log("theta:"+theta);
		Debug.Log("prepoint"+prepoint);
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space)){
			StartCoroutine (Tyousa ());
			start = true;
				Debug.Log("ok");
			}
		if(Senario1.kumaflag == true){
			StartCoroutine (Tyousa ());
			count = 0;
		}
		if(Senario2.kagoflag == true){
			StartCoroutine (Tyousa ());
			count = 0;
		}
		if(Senario2.makuraflag == true){
			StartCoroutine (Tyousa ());
			count = 0;
		}
		if(Senario3.taihouflag == true){
			StartCoroutine (Tyousa ());
			count = 0;
		}
		if(DemoMovie.flag == true){
			StartCoroutine (Tyousa ());
			count = 0;
		}
	}
	}

	

