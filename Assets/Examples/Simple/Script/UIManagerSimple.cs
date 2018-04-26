﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UIManagerSimple : MonoBehaviour {

    RenderSimple rs;

    public Button Btn_Switch;
    public GameObject Image_FaceDetect;



    void Awake()
    {
        rs = GetComponent<RenderSimple>();
        FaceunityWorker.instance.OnInitOK += InitApplication;
    }

    void InitApplication(object source, EventArgs e)
    {
        RegisterUIFunc();
    }


    void Update()
    {
        //TODO:添加UI响应返回键的功能
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (FaceunityWorker.fu_IsTracking() > 0)
            Image_FaceDetect.SetActive(false);
        else
            Image_FaceDetect.SetActive(true);
    }

    void RegisterUIFunc()
    {
        Btn_Switch.onClick.AddListener(delegate { rs.SwitchCamera(); });
    }

    void UnRegisterUIFunc()
    {
        Btn_Switch.onClick.RemoveAllListeners();
    }

    void OnApplicationQuit()
    {
        UnRegisterUIFunc();
    }
}