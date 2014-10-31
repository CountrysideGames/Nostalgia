using UnityEngine;
using System.Collections;

public class PogoController : MonoBehaviour {
	
	private float sideForce = 0;
	private float[] forceLimit = new float[] {-2.0f, 2.0f};


	void Start ()
	{
		Timer.success = true;
	}


	void Update()
	{
		if (Input.GetKey (KeyCode.A) || Input.acceleration.x < 0)
			sideForce += 1.5f;
		else if (Input.GetKey (KeyCode.D) || Input.acceleration.x > 0)
			sideForce -= 1.5f;

		transform.Rotate (0, 0, (transform.rotation.z + sideForce/50) * Game.time);


		if (Input.acceleration.x == 0)
		{
			//e der um toque e MOVER o dedo
#if !UNITY_EDITOR
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				if (Input.GetTouch (0).position.x > Screen.width/2)
				{
					sideForce += 1.5f;
				}
				else
				{
					sideForce -= 1.5f;
				}
			}
#endif
		}
	}

}