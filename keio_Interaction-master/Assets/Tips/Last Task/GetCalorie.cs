using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCalorie : MonoBehaviour
{
    //反映したいテキストオブジェクトを取得
    public Text title;

    int calorie = 0;

    // Start is called before the first frame update
    void Start()
    {
        calorie = InputInfoManager.getCalorie();
        title.text = "目標カロリー：" + calorie + " kcal";
        Debug.Log(calorie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
