using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    static GameHandler singleton = null;
    public int inputPlayer1 =0;
    public int inputPlayer1x =0;
    public int inputPlayer1y =0;
    public int inputPlayer2 =0;
    public int inputPlayer2x =0;
    public int inputPlayer2y =0;
    public int winner=0;
    public static GameHandler Singleton
    {
        get
        {
            singleton = FindObjectOfType(typeof(GameHandler)) as GameHandler;
            if(singleton == null)
            {
                GameObject g = new GameObject("GameHandler");
                singleton = g.AddComponent<GameHandler>();
            }
            return singleton;
        }
    }
    

   


}
