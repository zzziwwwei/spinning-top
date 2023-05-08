using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public GameObject ui_Start;
    public GameObject ui_rull;
    public GameObject nextStage;
    public GameObject sPoint;
    public GameObject cPoint;
    void Start()
    {
        ui_rull.SetActive(true);
        

    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Q)){
        StartCoroutine(St());
        ui_rull.SetActive(false);
        }
    }
    IEnumerator St()
    {
        
        ui_Start.SetActive(true);
       yield return new WaitForSeconds(3);
                ui_Start.SetActive(false);
                nextStage.SetActive(true);
                this.transform.gameObject.SetActive(false);


            yield return null;
        
    }

}
