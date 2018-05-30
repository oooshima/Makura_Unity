using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerihuController : MonoBehaviour {

	private Text Serihu;
	private float StartTime;
	private float NowTime;
	private float Timecount;
	private float time;
	private float timeeee;

	private bool flag = true;

	// Use this for initialization
	void Start () {
		Serihu = this.GetComponent<Text>(); // <---- 追加3
        Serihu.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	if(Senario2.DemoCount == 1){
			if(Senario2.kagoflag == true){
				Timecount += Time.deltaTime;
				if(Timecount > 3.0f){
					Serihu.text = "今日は森にきのみを取りに来たけど、";
				}
				if(Timecount > 10.0f){
					Serihu.text = "雨が降ってきてしまいました。";
				}
				if(Timecount > 15.0f){
					Serihu.text = "おや？";
					Senario2.SenarioCount = 1;
				}
				if(Timecount > 23.0f){
					Serihu.text = "大変！小鳥の兄弟が濡れちゃう！";
					Senario2.SenarioCount = 2;
				}
				if(Timecount > 28.0f && Senario2.SenarioCount <= 2){
					Serihu.text = "そのカゴで傘の下に移動してあげよう。";
					Senario2.SenarioCount = 3;
				}
			}
			if(Senario2.test == true){
				time += Time.deltaTime;
				if(time > 3.0f){
				Serihu.text = "これで安心だね！";
				}
			}
		}
	if(Senario2.DemoCount == 2){
			if(Senario2.Shizukuflag == true){
				Serihu.text = "その入れ物に雨を集めてみよう！";
			}
			if(Senario2.watercount >= 10){
				Serihu.text = "雨がやんだよ！！";
				}
			}
		if(Senario2.Demoflag == true){
			timeeee += Time.deltaTime;
			if(timeeee > 5.0f){
				Serihu.text = "雨が大好きなカエルさんが不機嫌になっちゃった。。。";
			}
			if(timeeee > 10.0f){
				Serihu.text = "その雨の雫を分けてあげよう！";
			}
		if(Senario2.kaerugladflag == false){
				Serihu.text = "カエルさんが喜んでるね！";
			}
		}
	}
}
