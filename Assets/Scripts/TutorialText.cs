using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    public GameObject text;

    void Start()
    {
        text.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            StartCoroutine("ReadWait");
        }
    }

    IEnumerator ReadWait()
    {
        yield return new WaitForSeconds(3);
        Destroy(text);
        Destroy(this.gameObject);
    }
}
