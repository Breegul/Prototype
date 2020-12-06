using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerMove player;
    private Canvas ui;

    private Text coinText;
    private float coinCount;

    private Text velText;
    private Text crosshair;

    void Start()
    {
        coinCount = 0;
        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        velText = GameObject.Find("VelocityText").GetComponent<Text>();
        crosshair = GameObject.Find("Crosshair").GetComponent<Text>();
    }

    void Update()
    {
        Vector3 vel = player.velocity;
        float y = player.yVelocity;
        velText.text = $"Vel: ({vel.x.ToString("0.0")}, {y.ToString("0.0")}, {vel.z.ToString("0.0")}) VelM: {vel.magnitude}";
        if(player.canHook) 
            {crosshair.color = Color.magenta;}
        else
            {crosshair.color = Color.green;}
    }

    public void collect()
    {
        coinCount++;
        coinText.text = "Coins Found: " + coinCount + "/5";
    }
}
