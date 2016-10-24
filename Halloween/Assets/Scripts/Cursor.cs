using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 point = ray.origin + ray.direction;

		transform.position = new Vector3(point.x, point.y);

	}
}
