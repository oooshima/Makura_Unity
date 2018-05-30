using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;

public class Makura {
	public float acc_x;
	public float acc_y;
	public float acc_z;
	public float acc_angle_x;
	public float acc_angle_y;
	public float acc_angle_z;
	public float corner1;
	public float corner2;
	public float corner3;
	public float corner4;

    public Makura(float acc_x, float acc_y, float acc_z, float acc_angle_x, float acc_angle_y,float acc_angle_z,float corner1,float corner2,float corner3,float corner4) {
        this.acc_x = acc_x;
        this.acc_y = acc_y;
        this.acc_z = acc_z;
        this.acc_angle_x = acc_angle_x;
        this.acc_angle_y = acc_angle_y;
		this.acc_angle_z = acc_angle_z;
		this.corner1 = corner1;
		this.corner2 = corner2;
		this.corner3 = corner3;
		this.corner4 = corner4;
    }
}

public class SerialTest : MonoBehaviour {
	public GameObject rocket;
	public static SerialLib.UnitySerial serial;
	public static int r;

	void Start()
	{
		serial = new SerialLib.UnitySerial ("/dev/cu.usbmodem1421", 9600, 256);
		serial.ThreadStart ();
	}

	void Update()
	{
		string str = serial.GetData ();
		if (str != null) {
			r = int.Parse (str);
			Debug.Log (r);

		}
		//Debug.Log (serial.GetData ());
	}

	void OnDestroy()
	{
		serial.ThreadEnd ();
	}
}