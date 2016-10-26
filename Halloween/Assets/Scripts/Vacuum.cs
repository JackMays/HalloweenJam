using UnityEngine;
using System.Collections;

public class Vacuum : MonoBehaviour {

	bool isVacuumActive = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		isVacuumActive = Input.GetMouseButton(0);
	}

	public bool HasVacuumActivated()
	{
		return isVacuumActive;
	}
}
