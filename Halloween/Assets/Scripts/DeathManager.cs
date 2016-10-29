using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeathManager : MonoBehaviour {

	string endScore = "";
	string endTime = "";

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BrotherHasDied()
	{
		Score score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
		Timer timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();

		timer.StopTimer();

		endScore = score.GetScore();
		endTime = timer.GetTime();

		SceneManager.LoadScene(2);
	}

	public string GetEndScore()
	{
		return endScore;
	}

	public string GetEndTime()
	{
		return endTime;
	}


}
