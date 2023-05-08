using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBattle : MonoBehaviour
{
    public GameObject player1Shaft;
    public GameObject player2Shaft;
    public GameObject centerOfPoint;
    public float r;
    public GameObject ui_1;
    public bool battleing = false;
    public Vector3 hitPosition;
    public GameObject nextStage;
    private void Start()
    {
        battleing = true;
        player1Shaft.transform.GetChild(0).GetComponent<FakeForce>().inputRotateSpeed = (Mathf.Abs(GameHandler.Singleton.inputPlayer1) - 20000) / 50;
        player2Shaft.transform.GetChild(0).GetComponent<FakeForce>().inputRotateSpeed = (Mathf.Abs(GameHandler.Singleton.inputPlayer2) - 20000) / 50;

        player1Shaft.transform.GetChild(0).GetComponent<FakeForce>().inputA = Mathf.Abs(GameHandler.Singleton.inputPlayer1x) / 4000 + 5;
        player2Shaft.transform.GetChild(0).GetComponent<FakeForce>().inputA = Mathf.Abs(GameHandler.Singleton.inputPlayer2x) / 4000 + 5;

        player1Shaft.transform.GetChild(0).GetComponent<FakeForce>().inputB = Mathf.Abs(GameHandler.Singleton.inputPlayer1y) / 4000 + 5;
        player2Shaft.transform.GetChild(0).GetComponent<FakeForce>().inputB = Mathf.Abs(GameHandler.Singleton.inputPlayer2y) / 4000 + 5;

        StartCoroutine(Battle());

    }
    IEnumerator Battle()
    {
        ui_1.SetActive(true);
        yield return new WaitForSeconds(4);
        ui_1.SetActive(false);
        yield return new WaitForSeconds(1);
        player1Shaft.SetActive(true);
        player2Shaft.SetActive(true);

        while (battleing)
        {
            if (r > Mathf.Sqrt(Mathf.Pow((Mathf.Abs(player1Shaft.transform.GetChild(0).position.x - player2Shaft.transform.GetChild(0).position.x)), 2) +
             Mathf.Pow((Mathf.Abs(player1Shaft.transform.GetChild(0).position.z - player2Shaft.transform.GetChild(0).position.z)), 2))&& player1Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>()&& player2Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>())
            {
                int ran = Random.Range(0, 3);
                print(ran);
                if (ran == 0)
                    player1Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>().Hit();
                if (ran == 1)
                    player2Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>().Hit();
                if (ran == 2)
                {
                    player1Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>().Hit();
                    player2Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>().Hit();
                }
            }

            if (15 < Mathf.Sqrt(Mathf.Pow((Mathf.Abs(player1Shaft.transform.GetChild(0).position.x - centerOfPoint.transform.position.x)), 2) +
             Mathf.Pow((Mathf.Abs(player1Shaft.transform.GetChild(0).position.z - centerOfPoint.transform.position.z)), 2)))
            {
                player1Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>().HitWall();
                print("hitwall");
            }
            if (15 < Mathf.Sqrt(Mathf.Pow((Mathf.Abs(player2Shaft.transform.GetChild(0).position.x - centerOfPoint.transform.position.x)), 2) +
             Mathf.Pow((Mathf.Abs(player2Shaft.transform.GetChild(0).position.z - centerOfPoint.transform.position.z)), 2)))
            {
                player2Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>().HitWall();
                print("hitwall");
            }

            if (player1Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>() == null && player2Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>())
            {
                GameHandler.Singleton.winner = 2;
            }
            if (player1Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>() && player2Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>() == null)
            {
                GameHandler.Singleton.winner = 1;
            }

            if (player1Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>() == null && player2Shaft.transform.GetChild(0).gameObject.GetComponent<FakeForce>() == null)
            {
                nextStage.SetActive(true);
                this.transform.gameObject.SetActive(false);
            }
            yield return null;
        }
    }


}