using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	Text timerText;

	float microSeconds = 0.0f;

	int seconds = 0;

	int minutes = 0;

	// Use this for initialization
	void Start () 
	{
		timerText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		microSeconds += Time.deltaTime;

		if (microSeconds >= 1)
		{
			++seconds;
			microSeconds = 0.0f;
		}

		if (seconds >= 60)
		{
			++minutes;
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
