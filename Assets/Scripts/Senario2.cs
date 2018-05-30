using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Senario2 : MonoBehaviour {

	public GameObject background1; //雨天時
	public GameObject Rain;
	public GameObject kago;
	public GameObject birdbrother;
	public GameObject umbrella;
	public GameObject shizuku;
	public GameObject raincreator;
	public GameObject pot;
	public GameObject kaeru_sad;
	public GameObject kaeru_glad;
	public GameObject makura;
	public GameObject kirakira;
	

	private GameObject Background1;
	private GameObject Kago;
	private GameObject Birdbrother;
	private GameObject Umbrella;
	private GameObject Shizuku;
	private GameObject Pot;
	private GameObject Kaeru_sad;
	private GameObject Kaeru_glad;
	private GameObject Makura;
	private GameObject ase;
	private GameObject water1;
	private GameObject water2;
	private GameObject water3;
	private AudioSource rain_sound;
	private AudioSource water_sound;
	private AudioSource kirakira_sound;

	private Rigidbody2D kaeru;
	
	public Sprite Pot2;
	public Sprite Pot3;
	public Sprite Pot4;
	public Sprite background_sunny;
	public AudioClip rainclip;
	public AudioClip kirakiraclip;

	public static int watercount = 0;
	public static int DemoCount = 1;
	
	private float kyori;
	private Image birdimage;
	private Image umbrellaimage;
	private Image potimg;
	private Image sunimg;
	private Image aseimg;
	private Image image2;
	private Image water_img1;
	private Image water_img2;
	private Image water_img3;

	private float kago_bird;
	private float bird_umbrella = 300f;
	private float kaeru_pot;
	private float makurakyori;
	private int birdcount = 0;
	private int umbrellacount = 0;
	private float shizukuinterval = 3.0f;
	private float time;
	
	private bool umbrellaflag = true;
	private bool birdflag = true;
	private bool movebirdflag = false;
	public static  bool Shizukuflag = false;
	private bool potflag = true;
	private bool kaeruflag = false;
	private bool pushflag = false;
	private bool rainflag = true;
	public static  bool test = false;
	public static bool makuraflag = false;

	public static int SenarioCount = 0;
	public static int KaeruCount = 0;
	public static bool kagoflag = false;
	public static bool kaerugladflag = true;
	public static bool Demoflag = false;

	// Use this for initialization
	void Start () {
		rain_sound = this.gameObject.GetComponent<AudioSource>();
		kirakira_sound = this.gameObject.GetComponent<AudioSource>();
		Makura = Instantiate(makura);
		Makura.transform.parent = GameObject.Find("Canvas").transform;
		Makura.GetComponent<RectTransform>().anchoredPosition = new Vector3(-19.91f,50.5f,0f);
		Makura.GetComponent<RectTransform>().localScale = new Vector3(3.11f,2.4f,2.0f);
		Makura.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0f, 90f);
		makuraflag = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(makuraflag == true){
		makurakyori = KyoriKeisan(new Vector2(WebcamCapture.centerx,WebcamCapture.centery-480f),new Vector2(-19.91f,50.5f));
			if(makurakyori < 490f){
				time += Time.deltaTime;
				if(time > 3.0f){
					WebcamCapture.start = true;
					makuraflag = false;
				}
			}
		}
		Debug.Log("makikyori"+makurakyori);
		//Debug.Log(watercount);
		//Debug.Log("f"+DoSomething.f);
		Vector3 RaincreatorPos = raincreator.transform.position;

		if(Input.GetKeyDown(KeyCode.S)){
				DemoCount = 2;
				Shizukuflag = true;
				Destroy(Kago.gameObject);
				Destroy(Birdbrother.gameObject);
				Destroy(Umbrella.gameObject);
			}
		if(Input.GetKeyDown(KeyCode.F)){
				kaeruflag = true;
				Shizukuflag = true;
				sunimg.sprite = background_sunny;
				Rain.SetActive(false);
				kirakira_sound.clip = kirakiraclip;
			
				//kagoflag = false;
				//Destroy(Kago.gameObject);
			}
	if(DemoCount == 2){			
		if(Shizukuflag == true){
			if(potflag == true){
			Pot = Instantiate(pot);
			potimg = Pot.gameObject.GetComponent<Image>();
			ase = GameObject.Find("ase");
			Pot.transform.parent = GameObject.Find("Canvas").transform;
			Pot.GetComponent<RectTransform>().localPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,17f);
			Pot.GetComponent<RectTransform>().localScale = new Vector3(2.0f,2.0f,1.5f);
			Pot.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180f, 0);
			potflag = false;
			}
			if(watercount == 3){
				potimg.sprite = Pot2;
			}
			if(watercount == 7){
				potimg.sprite = Pot3;
			}
			if(watercount == 10){
				potimg.sprite = Pot4;
				sunimg.sprite = background_sunny;
				Shizukuflag = false;
			}
			shizukuinterval -= Time.deltaTime;
		if(shizukuinterval < 0){
			Shizuku = Instantiate(shizuku);
			Shizuku.transform.parent = GameObject.Find("Canvas").transform;
			Shizuku.GetComponent<RectTransform>().localPosition = new Vector3(RaincreatorPos.x+=Random.Range(-10f,300f),100f,17.0f);
			Shizuku.GetComponent<RectTransform>().anchoredPosition = new Vector3(RaincreatorPos.x+=Random.Range(-10f,300f),100f,17.0f);
			Shizuku.GetComponent<RectTransform>().localScale = new Vector3(1.5f,1.5f,1.5f);
			Shizuku.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0f, 0);
			shizukuinterval = 3.0f;
				}
			}

			if(potflag == false){
			Pot.GetComponent<RectTransform>().anchoredPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,17f);
			//Pot.GetComponent<RectTransform>().localScale *= WebcamCapture.Size; 
			//Pot.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180f-Mathf.Abs(DoSomething.diff_acc_angle_y), Kago.GetComponent<RectTransform>().localRotation.z-WebcamCapture.theta);
			}
			if((DoSomething.diff_a0 > 0.5f && DoSomething.diff_a1 > 0.5f)||(DoSomething.diff_a2 > 0.5f && DoSomething.diff_a3 > 0.5f)){
				pushflag = true;
				ase.SetActive(true);
				kirakira_sound.Play();
				}else{
				pushflag = false;
				ase.SetActive(false);
				}

			if(kaeruflag == true){
			Kaeru_sad = Instantiate(kaeru_sad);
			Kaeru_sad.transform.parent = GameObject.Find("Canvas").transform;
			Kaeru_sad.GetComponent<RectTransform>().localPosition = new Vector3(430f,-378f,0f);
			Kaeru_sad.GetComponent<RectTransform>().anchoredPosition = new Vector3(430f,-378f,0f);
			Kaeru_sad.GetComponent<RectTransform>().localScale = new Vector3(7.0f,2.5f,2.0f);
			Kaeru_sad.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
			kaeruflag = false;
			Shizukuflag = false;
			Demoflag = true;
		}
		if(kaeruflag == false){
			//kaeru_pot = KyoriKeisan(new Vector2(WebcamCapture.centerx,WebcamCapture.centery-480f),new Vector2(510.41f,-378f));
			if(/*kaeru_pot < 50f && */pushflag == true){
				KaeruCount += 1;
				Debug.Log("count"+KaeruCount);
				if(KaeruCount > 150 && kaerugladflag == true){
					Debug.Log("ok");
					Destroy(Kaeru_sad);
					Kaeru_glad = Instantiate(kaeru_glad);
					Kaeru_glad.transform.parent = GameObject.Find("Canvas").transform;
					Kaeru_glad.GetComponent<RectTransform>().localPosition = new Vector3(430f,-378f,0f);
					Kaeru_glad.GetComponent<RectTransform>().anchoredPosition = new Vector3(430f,-331f,0f);
					Kaeru_glad.GetComponent<RectTransform>().localScale = new Vector3(5.0f,4.0f,2.0f);
					Kaeru_glad.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
					kaerugladflag = false;
				}
			}
		}
	}
	

	if(DemoCount == 3){
			if(DoSomething.f > 35f && rainflag == true){	
			rain_sound.clip = rainclip;
			rain_sound.Play();
			rainflag = false;
			}
		}
			
		
		if(WebcamCapture.start == true){
			Destroy(Makura);

			Rain.SetActive(true);

			Background1 = Instantiate(background1);
			sunimg = Background1.gameObject.GetComponent<Image>();
			Background1.transform.parent = GameObject.Find("Canvas").transform;
			Background1.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
			Background1.GetComponent<RectTransform>().localScale = new Vector3(1.0f,1.0f,1.0f);
			Background1.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
			
			Kago = Instantiate(kago);
			Kago.transform.parent = GameObject.Find("Canvas").transform;
			Kago.GetComponent<RectTransform>().localPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,-50f);
			Kago.GetComponent<RectTransform>().localScale = new Vector3(6.0f,2.5f,1.5f);
			Kago.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0f, 0);
			kagoflag = true;

			WebcamCapture.start = false;
		}

		if(kagoflag == true){
			Kago.GetComponent<RectTransform>().anchoredPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,-50f);
			//Kago.GetComponent<RectTransform>().localScale *= WebcamCapture.Size; 
			//Kago.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, /*180f-DoSomething.diff_acc_angle_y*/0, Kago.GetComponent<RectTransform>().localRotation.z+WebcamCapture.theta);
		}
		
			

		if(SenarioCount == 1 && birdflag == true){
			Birdbrother = Instantiate(birdbrother);
			Birdbrother.transform.parent = GameObject.Find("Canvas").transform;
			Birdbrother.GetComponent<RectTransform>().localPosition = new Vector3(450f,-378f,0f);
			Birdbrother.GetComponent<RectTransform>().anchoredPosition = new Vector3(450f,-378f,0f);
			Birdbrother.GetComponent<RectTransform>().localScale = new Vector3(9.0f,3.0f,2.0f);
			Birdbrother.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
			birdflag = false;
		}
		if(birdflag == false){
			PlusAlpha(birdimage,Birdbrother,birdcount = PlusAlpha(birdimage,Birdbrother,birdcount));
		}

		if(SenarioCount == 2 && umbrellaflag == true){
			Umbrella = Instantiate(umbrella);
			Umbrella.transform.parent = GameObject.Find("Canvas").transform;
			Umbrella.GetComponent<RectTransform>().localPosition = new Vector3(163f,-299f,0f);
			Umbrella.GetComponent<RectTransform>().anchoredPosition = new Vector3(163f,-299f,0f);
			Umbrella.GetComponent<RectTransform>().localScale = new Vector3(14f,6.6f,1.0f);
			Umbrella.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
			umbrellaflag = false;
		}
		if(umbrellaflag == false){
			PlusAlpha(umbrellaimage,Umbrella,umbrellacount = PlusAlpha(umbrellaimage,Umbrella,umbrellacount));
		}

		if(SenarioCount == 3){
			kago_bird = KyoriKeisan(new Vector2(WebcamCapture.centerx,WebcamCapture.centery-480f),new Vector2(450f,-378f));
			//Debug.Log("y = "+DoSomething.diff_acc_angle_y);
			if(kago_bird < 90f && DoSomething.diff_acc_angle_y > 30f){
				movebirdflag = true;
				}
			if(movebirdflag == true){
				Birdbrother.GetComponent<RectTransform>().anchoredPosition = new Vector3(WebcamCapture.centerx,WebcamCapture.centery-480f,-50f);	
				//Birdbrother.GetComponent<RectTransform>().localScale *= WebcamCapture.Size; 
				//Birdbrother.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180f-DoSomething.diff_acc_angle_y, Kago.GetComponent<RectTransform>().localRotation.z-WebcamCapture.theta);
				bird_umbrella = KyoriKeisan(new Vector2(WebcamCapture.centerx,WebcamCapture.centery-480f),new Vector2(163f,-378f));
				//Debug.Log("kyori = "+bird_umbrella);
			}
			if(bird_umbrella < 70f && DoSomething.diff_acc_angle_y > 30f){
				Birdbrother.GetComponent<RectTransform>().localPosition = new Vector3(104.63f,-378f,0f);
				Birdbrother.GetComponent<RectTransform>().anchoredPosition = new Vector3(104.63f,-378f,0f);
				movebirdflag = false;
				SenarioCount = 4;
			}
			if(SenarioCount == 4){
				test = true;
			}
		}
	}

	float KyoriKeisan(Vector2 target1,Vector2 target2){
		float kyori = Vector2.Distance(target1,target2);
		return kyori;
	}

	int PlusAlpha(Image image, GameObject obj, int count){
		image = obj.gameObject.GetComponent<Image>();
		var color = image.color;
		if(count == 0){
			color.a = 0;
			image.color = color;
			count = 1;
		}
		if(image.color.a < 1f){
			color = image.color;
			color.a += 0.01f;
			image.color = color;
		}
		return count;
	}
}
