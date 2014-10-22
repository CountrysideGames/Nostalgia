using UnityEngine;
using System.Collections;

public class RivalController : MonoBehaviour {


	private float[] positionX = new float[] {0.347f, -0.314f}; //posições X em que o jogador pode nascer


	void Start ()
	{
		//coloca o carro numa posição random do eixo X (Xposition)
		transform.localPosition = new Vector2 (positionX [Random.Range (0, positionX.Length)], transform.localPosition.y);

		InvokeRepeating ("MoveDown", Game.time/5, Game.time/5);
	}

	//faz o carro descer
	void MoveDown ()
	{
		transform.localPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y - 0.33f * Game.time);
		
		if (Game.time == 0)
			CancelInvoke ();
	}

}
