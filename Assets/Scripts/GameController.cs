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
        velText.text = "Vel: "+player.velocity.ToString("0.00");
    }

    public void collect()
    {
        coinCount++;
        coinText.text = "Coins Found: " + coinCount + "/5";
    }
}
