using UnityEngine;
using System.Collections;

public class RaceController : MonoBehaviour {



	public Animator playerCarAnimator;
	private float speed = 0;


	void Update ()
	{
		if (Input.GetKey (KeyCode.Space) && playerCarAnimator.GetInteger ("state") < 2)
		{
			if (speed < .15f)
			{
				speed += 0.01f;
				print (speed);
				playerCarAnimator.speed += speed;
				playerCarAnimator.SetInteger ("state", 1); //CHAMA ANIMAÇAO RUN
			}
		}
	}

	void SpeedCheck ()
	{
		if (speed >= .15f && playerCarAnimator.GetInteger ("state") == 1)
		{
			playerCarAnimator.SetInteger ("state", 2); //CHAMA ANIMAÇAO FALL
			playerCarAnimator.speed = 1;
		}
	}

	void End ()
	{
		playerCarAnimator.SetInteger ("state", 3); //CHAMA ANIMAÇAO END
	}
}
