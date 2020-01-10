using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Loading()
    {
        GameObject.Find("SettingPanel").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
