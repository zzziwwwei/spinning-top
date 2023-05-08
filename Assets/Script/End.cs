using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ui_1;
    public GameObject ui_2;
    public GameObject ui_3;
    void Start()
    {
        if (GameHandler.Singleton.winner == 1)
        {
            ui_1.SetActive(true);
        }
        if (GameHandler.Singleton.winner == 2)
        {
            ui_2.SetActive(true);
        }
        if (GameHandler.Singleton.winner == 0)  
        {    ui_3.SetActive(true);
        }
     

    }

    // Update is called once per frame

}
