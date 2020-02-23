using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILog : MonoBehaviour
{
    public Text txtlog;
    public bool showLog = true;
    public GameObject panelLog;


   
    void Start()
    {
        if (!showLog)
        {
            panelLog.SetActive(false);
        }
    }

    public void setText(string s)
    {
        txtlog.text = s;
    }
}
