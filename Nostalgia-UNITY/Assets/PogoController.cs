using UnityEngine;
using System.Collections;

public class PogoController : MonoBehaviour {


	private Quaternion rotation = Quaternion.identity;
	private float sideForce = 0;

	void Start ()
	{
		sideForce = Random.Range (-1.0f, 1.0f);
		rotation.eulerAngles = new Vector3(0, 0, rotation.eulerAngles.z + (Input.acceleration.z + sideForce));
		transform.rotation = rotation;
	}

	void Update()
	{
		if (Input.acceleration.z > 0)
			sideForce = .6f;
		else
			sideForce = -.6f;

		rotation.eulerAngles = new Vector3(0, 0, rotation.eulerAngles.z + (Input.acceleration.z + sideForce) * Game.time);
		transform.rotation = rotation;
	}


}