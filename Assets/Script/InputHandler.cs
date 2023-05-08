using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class InputHandler : MonoBehaviour
{
    public string inputSpeed;
    public bool reading;
    public SerialPort port = new SerialPort("COM3", 38400);
    void Start()
    {
        port.Open();
        inputSpeed = "";
        reading = true;
        StartCoroutine(Read());
        

    }
    public string gy, gx, gz;


    IEnumerator Read()
    {
        while (reading)
        {
            if (port.IsOpen)
            {
                inputSpeed = port.ReadLine();
            }
            print(inputSpeed);
            yield return null;
        }
    }
}
