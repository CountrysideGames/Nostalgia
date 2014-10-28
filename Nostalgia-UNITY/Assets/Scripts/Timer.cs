using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	//CONTADOR REGRESSIVO DE TEMPO DA FASE


	public float speed = 0.2f; //tempo que leva para reduzir a escala da barra de tempo
	public static bool success = false;

	void Awake ()
	{
		success = false;
	}

	void Update ()
	{
		if (transform.localScale.x >= 0)
			transform.localScale = new Vector2 (transform.localScale.x - (speed * Time.deltaTime) * Game.time, transform.localScale.y);
		else
		{
			Game.EndLevel (success); //termina a fase sem sucesso
		}
	}


}
