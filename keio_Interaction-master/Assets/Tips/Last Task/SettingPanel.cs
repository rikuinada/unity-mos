﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SettingPanel").SetActive(false);
        GameObject.Find("SettingPanel").GetComponent<Renderer>().material.color = new Color(0, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
