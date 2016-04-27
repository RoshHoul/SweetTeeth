using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    float timeLeft = 300.0f;

    public Text text;
    
	
	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;
        text.text = "Time left: " + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            Debug.Log("Gubish");
        }
	}
}
