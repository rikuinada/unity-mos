using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class InputInfoManager : MonoBehaviour
{
    //入力フォーム(文字列)
    public InputField age, weight, height;
    //トグルの値の取得
    public ToggleGroup toggleGroup;
    //Dropdownの値の取得
    public Dropdown dropdownComponent;
    //消費カロリー　（外部からアクセスするためstaticで宣言して値を返す）
    public static double calorie;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool CheckType(string str)
    {
        //doubleに変換できるか確かめる
        double d;
        if (double.TryParse(str, out d))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void onclick()
    {
        //入力フォームの値の取得
        Debug.Log(age.text);
        Debug.Log(weight.text);
        Debug.Log(height.text);

        //ドロップダウンの値の取得
        Debug.Log(dropdownComponent.value);

        //ラジオボタンの値の取得
        string selectedLabel = toggleGroup.ActiveToggles()
            .First().GetComponentsInChildren<Text>()
            .First(t => t.name == "Label").text;

        Debug.Log("selected " + selectedLabel);
        if (CheckType(age.text) && CheckType(weight.text) && CheckType(height.text)) 
        {
            //男性：13.397×体重kg＋4.799×身長cm−5.677×年齢+88.362
            //女性：9.247×体重kg＋3.098×身長cm−4.33×年齢+447.593
            //ここに運動強度を掛け合わせる
            if (selectedLabel == "男")
            {
                calorie = 13.3 * double.Parse(weight.text) + 4.8 * double.Parse(height.text) - 5.7 * double.Parse(age.text) + 88.4;
            }
            else
            {
                calorie = 9.2 * double.Parse(weight.text) + 3.1 * double.Parse(height.text) - 4.3 * double.Parse(age.text) + 447.6;
            }

            SceneManager.LoadScene("MainScene");    //フリップシーンへ
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("SettingPanel").gameObject.SetActive(true);
        }
    }

    public static double getCalorie()
    {
        return calorie;
    }

    public static void updateCalorie(double newCalorie)
    {
        calorie = newCalorie;
    }
}
