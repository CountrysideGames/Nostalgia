using UnityEngine;
using System.Collections;

public class PogoCollider : MonoBehaviour {


	public int impulse = 2;


	void OnCollisionEnter2D (Collision2D col)
	{
		if (transform.localRotation.z > -110)
		{
			rigidbody2D.AddForce (Vector2.up * 100 * impulse );
		}
	}

}
