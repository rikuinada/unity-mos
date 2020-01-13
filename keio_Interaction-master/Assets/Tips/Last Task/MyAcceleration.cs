using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MyAcceleration : MonoBehaviour {

    float speed = 10.0f;
    Vector3 center;
    public static Vector3 dir;
    public static int count = 0;
    public static bool movement;
    Vector3[] acc;
    int index = 0;    //配列のインデックス


    // Use this for initialization
    void Start () {
        acc = new Vector3[600];    //配列を初期化
        center = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        float scale = 5f;
        dir = Input.acceleration;//スマホの加速度取得

        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }

        acc[index++ % 600] = dir; //スマホの加速度を保存
        
        //球に位置を反映
        Vector3 pos = new Vector3(
            center.x + dir.x * scale,
            center.y + dir.y * scale,
            center.z + dir.z * scale
        );

        this.transform.position = pos;

        if(index >= 30)
        {
            //Debug.Log(index);
            if(Math.Abs(acc[(index % 600) - 30].z - dir.z) >= 0.7)
            {
                movement = true;
            }
            else
            {
                count++;
            }
        }

        if(count >= 10)
        {
            movement = false;
            count = 0;
        }

    }

    private void OnGUI ()
    {

    }


    public static Vector3 getDir()
    {
        //Debug.Log(dir);
        return dir;
    }

    public static bool getMotion()
    {
        //Debug.Log(dir);
        return movement;
    }


}
