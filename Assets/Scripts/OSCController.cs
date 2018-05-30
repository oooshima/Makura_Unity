using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCController : MonoBehaviour {
private long lastTimeStamp = 0;
	// Use this for initialization
	void Start () {
		OSCHandler.Instance.Init();
	}
	
	// Update is called once per frame
	void Update () {
	 //  受信データの更新
        OSCHandler.Instance.UpdateLogs();
        //  受信データの解析
        foreach (KeyValuePair<string, ServerLog> item in OSCHandler.Instance.Servers) {
            for (int i=0; i < item.Value.packets.Count; i++) {
                if (lastTimeStamp < item.Value.packets[i].TimeStamp) {
                    lastTimeStamp = item.Value.packets[i].TimeStamp;
                    //  アドレスパターン（文字列）
                    string address = item.Value.packets[i].Address;
                    //  引数（とりあえず最初の引数のみ）
                    var arg0 = item.Value.packets[i].Data[0];
                    var arg1 = item.Value.packets[i].Data[1];
                    //  処理（とりあえずコンソール出力）
                    Debug.Log(address + ":" + arg0);
                    Debug.Log(address + ":" + arg1);
                }
            }
        }
	}
}

