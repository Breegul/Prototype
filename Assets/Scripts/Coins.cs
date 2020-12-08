using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("Game").GetComponent<GameController>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(45, 0, 0)*Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            gameController.collect();
        }
    }
}
