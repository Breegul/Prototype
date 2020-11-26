using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerMove player;

    public Text coinText;
    private float coinCount;

    public Text velText;

    void Start()
    {
        coinCount = 0;
    }

    void Update()
    {
        Vector3 vel = player.velocity;
        float y = player.yVelocity;
        velText.text = $"Vel: ({vel.x.ToString("0.0")}, {y.ToString("0.0")}, {vel.z.ToString("0.0")}) VelM: {vel.magnitude}";
    }

    public void collect()
    {
        coinCount++;
        coinText.text = "Coins Found: " + coinCount + "/5";
    }
}
