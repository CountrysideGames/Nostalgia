using UnityEngine;
using System.Collections;

public class PogoController : MonoBehaviour {


	private Quaternion rotation = Quaternion.identity;
	private float sideForce = 0;
	private float[] forceLimit = new float[] {-5.0f, 5.0f};


	void Start ()
	{
		Timer.success = true;

		sideForce = forceLimit [Random.Range (0, 2)];
	}


	void Update()
	{
		if (Input.GetKey (KeyCode.A) || Input.acceleration.x < 0)
			sideForce += 1.5f;
		else if (Input.GetKey (KeyCode.D) || Input.acceleration.x > 0)
			sideForce -= 1.5f;

		transform.Rotate (0, 0, (transform.rotation.z + sideForce/50) * Game.time);
	}

}