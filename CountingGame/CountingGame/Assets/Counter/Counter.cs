using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private static int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Ball"))
            return;
        other.gameObject.tag = "Untagged";
        switch (gameObject.tag)
        {
            case "Magenta":
                Count += 5; break;
            case "Yellow":
                Count += 2; break;
            case "Cyan":
                Count += 10; break;
            case "Black":
                Count -= 1; break;
            default:
                Debug.Log("Def"); break;
        }
        CounterText.text = "Score : " + Count;
    }
}
