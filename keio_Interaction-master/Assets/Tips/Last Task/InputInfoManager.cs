using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class InputInfoManager : MonoBehaviour
{
    //入力フォーム
    public InputField age, weight, height;
    //トグルの値の取得
    public ToggleGroup toggleGroup;
    //Dropdownの値の取得
    public Dropdown dropdownComponent;

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
            SceneManager.LoadScene("MainScene");    //フリップシーンへ
        }
        else
        {
            Debug.Log("else文");
            GameObject.Find("Canvas").transform.Find("SettingPanel").gameObject.SetActive(true);
        }
    }

}
