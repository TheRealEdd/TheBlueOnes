using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation1 : MonoBehaviour
{

	public Vector3[] path = new Vector3[5];

	public Transform[] waypoints = new Transform [4];

	int pathIndex = 0;

	public float speed = 50;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 target = waypoints[pathIndex].position;
		Vector3 newPos = Vector3.MoveTowards( transform.position, target, speed * Time.deltaTime );

		transform.position = newPos;
		transform.LookAt( target );

		// have I arrived?
		if( Vector3.Distance( newPos, target ) == 0 )
		{
			pathIndex = ++pathIndex % path.Length;
		}
	}
}
