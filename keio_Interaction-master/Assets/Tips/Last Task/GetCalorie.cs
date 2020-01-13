using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GetCalorie : MonoBehaviour
{
    //反映したいテキストオブジェクトを取得
    public Text title;

    double calorie = 0;

    // Start is called before the first frame update
    void Start()
    {
        calorie = InputInfoManager.getCalorie();
        title.text = (Math.Round(calorie, 2)).ToString();
        //Debug.Log((int)(calorie));
    }

    // Update is called once per frame
    void Update()
    {
        calorie = InputInfoManager.getCalorie();
        title.text = (Math.Round(calorie, 2)).ToString();
    }
}
