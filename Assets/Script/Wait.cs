using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ui_1;
    public GameObject nextStage;
    
    void Start()
    {
        ui_1.SetActive(true);
        StartCoroutine(p());

    }

    // Update is called once per frame
    IEnumerator p()
    {

        yield return new WaitForSeconds(8); 
        ui_1.SetActive(false);
        nextStage.SetActive(true);
        this.transform.gameObject.SetActive(false);
        yield return null;

    }
}
