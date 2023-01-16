using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
	public GameObject[] waypoints;
	int curIdx = 0;

	public float tolerance = 10;
	public float mvSpeed = 10.0f;
	public float rtSpeed = 10.0f;

	// Start is called before the first frame update
	void Start()
	{
		// No action needed
	}

	// Update is called once per frame
	void Update()
	{
		if (Vector3.Distance(this.transform.position, waypoints[curIdx].transform.position) < tolerance)
			curIdx = (curIdx + 1) % waypoints.Length;

		// Slerp towards the next waypoint
		Quaternion slerpQuat = Quaternion.LookRotation(waypoints[curIdx].transform.position - this.transform.position);
		this.transform.rotation = Quaternion.Slerp(transform.rotation, slerpQuat, rtSpeed=Time.deltaTime);

		// Head towards the next waypoint
		this.transform.Translate(0, 0, mvSpeed*Time.deltaTime);
	}
}
