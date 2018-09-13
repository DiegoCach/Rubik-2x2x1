using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {
    private Text timer;
    private float timeElapsed;

	// Use this for initialization
	void Start () {
        timer = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;
        string minutes = (timeElapsed / 120).ToString("00");
        string seconds = (timeElapsed % 60).ToString("00");

        timer.text = minutes + ":" + seconds;
	}
}
