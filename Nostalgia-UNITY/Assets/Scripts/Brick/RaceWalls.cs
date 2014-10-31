using UnityEngine;
using System.Collections;

public class RaceWalls : MonoBehaviour {

	
	void Start ()
	{
		//CHAMA A FUNCAO MOVEDOWN A CADA 0.2 SEGUNDOS
		InvokeRepeating ("MoveDown", 0.2f, 0.2f);
	}
	
	void MoveDown ()
	{
		//MOVE O WALLS 0.33 PARA BAIXO
		transform.localPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y - 0.33f * Game.time * 2.0f);

		//SE O GAME.TIME FICAR 0, CANCELA A MOVIMENTACAO
		if (Game.time == 0)
			CancelInvoke ();
	}

	void Update ()
	{
		if (transform.localPosition.y < -1.265f) //PASSAR DESSA POSICAO Y
			transform.localPosition = new Vector2 (0, 0.05f); //VOLTA O WALLS PARA A POSICAO INICIAL
	}

}
