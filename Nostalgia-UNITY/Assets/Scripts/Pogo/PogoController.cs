using UnityEngine;
using System.Collections;

public class PogoController : MonoBehaviour {


	private Quaternion rotation = Quaternion.identity;
	private float sideForce = 0;



	void Start ()
	{
		Timer.success = true;

		sideForce = Random.Range (-10, 10);
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.A) || Input.acceleration.x < 0)
			sideForce += 1;
		else if (Input.GetKey (KeyCode.D) || Input.acceleration.x > 0)
			sideForce -= 1;

		transform.Rotate (0, 0, transform.rotation.z + sideForce/50);
	}

}