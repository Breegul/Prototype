using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerMove player;
    private Canvas ui;
    private LevelLoader loader;

    private Text coinText;
    private float coinCount;
    private Text crosshair;

    //private Text velText;

    void Start()
    {
        coinCount = 0;
        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        crosshair = GameObject.Find("Crosshair").GetComponent<Text>();
        loader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        //velText = GameObject.Find("VelocityText").GetComponent<Text>();
    }

    void Update()
    {
        /*
        Vector3 vel = player.velocity;
        float y = player.yVelocity;
        velText.text = $"Vel: ({vel.x.ToString("0.0")}, {y.ToString("0.0")}, {vel.z.ToString("0.0")}) VelM: {vel.magnitude}";
        */
        if(player.canHook) 
            {crosshair.color = Color.magenta;}
        else
            {crosshair.color = Color.green;}
        
        if(coinCount == 5)
        {
            loader.LoadNext();
        }
    }

    public void collect()
    {
        private int maxcoins;
        coinCount++;
        coinText.text = "Coins Found: " + coinCount + maxcoins;

    }
}
