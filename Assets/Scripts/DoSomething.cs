using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoSomething : MonoBehaviour
{
  //先ほど作成したクラス
  public SerialHandler serialHandler;
	private List<float> Message = new List<float>();
  private float diff_acc_x;
	private float diff_acc_y;
	private float diff_acc_z;
	public static float diff_acc_angle_x;
	public static float diff_acc_angle_y;
	public static float diff_acc_angle_z;
	public static float diff_a0;
	public static float diff_a1;
	public static float diff_a2;
	public static float diff_a3;
  public static int f;
 




  void Start()
  {
     //信号を受信したときに、そのメッセージの処理を行う
     serialHandler.OnDataReceived += OnDataReceived;
  }

  void Updata()
  {
    //文字列を送信
    serialHandler.Write("hogehoge");

  }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        var data = message.Split(
                new string[]{"\t"}, System.StringSplitOptions.None);
        if (data.Length < 2) return;
        try {
          diff_acc_x = float.Parse(data[0]);
		      diff_acc_y = float.Parse(data[1]);
          diff_acc_z = float.Parse(data[2]);
          diff_acc_angle_x = float.Parse(data[3]);
          diff_acc_angle_y = float.Parse(data[4]);
          diff_acc_angle_z = float.Parse(data[5]);
          diff_a0 = float.Parse(data[6]);
          diff_a1 = float.Parse(data[7]);
          diff_a2 = float.Parse(data[8]);
          diff_a3 = float.Parse(data[9]);
          f = int.Parse(data[10]);
      
         
		   Debug.Log(diff_acc_x);
		   Debug.Log(diff_acc_y);
       Debug.Log(diff_acc_z);
       Debug.Log(diff_acc_angle_x);
       Debug.Log(diff_acc_angle_y);
       Debug.Log(diff_acc_angle_z);
       Debug.Log(diff_a0);
       Debug.Log(diff_a1);
       Debug.Log(diff_a2);
       Debug.Log(diff_a3);
       
        } catch (System.Exception e) {
            Debug.LogWarning(e.Message);
        }
    }
}
