using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	SpeedManager speed;

	Text timerText;

	float microSeconds = 0.0f;

	int seconds = 0;

	int minutes = 0;

	int speedUpInterval = 10;

	int speedUpIncrement = 0;

	// Use this for initialization
	void Start () 
	{
		speed = GameObject.FindGameObjectWithTag("Speed").GetComponent<SpeedManager>();
		timerText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		microSeconds += Time.deltaTime;

		if (microSeconds >= 1)
		{
			++seconds;
			++speedUpIncrement;
			microSeconds = 0.0f;
		}

		if (speedUpIncrement >= speedUpInterval)
		{
			speed.SpeedUp();
			speedUpIncrement = 0;

			Debug.Log("speed = interval");
		}

		if (seconds >= 60)
		{
			++minutes;
			seconds = 0;
		}

		if (minutes < 10)
		{
			timerText.text = "0" + minutes + ":";
		}
		else
		{
			timerText.text = minutes + ":";
		}

		if (seconds < 10)
		{
			timerText.text += "0" + seconds;
		}
		else
		{
			timerText.text += seconds;
		}


	}
}
