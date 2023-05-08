using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using UnityEngine.UI;
public class InputSpeed2 : MonoBehaviour
{
    public SerialPort port = new SerialPort("COM3", 115200);
    public int k;
    public string input;
    public string gx;
    public string gy;
    public bool jing = false;
    public GameObject nextStage;
    public GameObject ui_Start;// Start is called before the first frame update
    void Start()
    {
        port.Open();
        port.ReadTimeout = 0;
        ui_Start.SetActive(true);
        input = "";
        gx = "";
        gy = "";

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (port.IsOpen && !jing)
        {
            try
            {
                input = port.ReadLine();
                gx = port.ReadLine();
                gy = port.ReadLine();
                GameHandler.Singleton.inputPlayer2 = int.Parse(input);
                GameHandler.Singleton.inputPlayer2x = int.Parse(gx);
                GameHandler.Singleton.inputPlayer2y = int.Parse(gy);
                port.Close();
                jing = true;
                j();
            }

            catch (TimeoutException)
            {

            }
        }

    }
    void j()
    {
        StartCoroutine(End());
    }
    IEnumerator End()
    {
        yield return new WaitForSeconds(1);
        ui_Start.SetActive(false);
        nextStage.SetActive(true);
        this.transform.gameObject.SetActive(false);
        yield return null;
    }

}
