using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	//ESTA CLASSE ARMAZENA AS VARIAVEIS E FUNÇÕES GLOBAIS MAIS IMPORTANTES


	public static int score = 0;
	public static int chances = 3; //conta o numero de chances UTILIZADAS
	public static float time = 1; //define o tempo do jogo (similar ao Time.timeScale)
	public static bool isPaused = false; //indica se o jogo está pausado
	public static bool levelComplete = false; //indica se a missao foi completa (sucesso)

	private static List<string> levels = new List<string>() {"Blow", "Brick", "Pogo", /*"Race", */"Tape"}; //lista de fases
	public static List<string> playedLevels = new List<string> (); //lista de fases jogadas na sessão


	void Start ()
	{
		Reset ();
	}

	public static void Reset ()
	{
		score = 0;
		chances = 3;
		time = 1;
		isPaused = false;
		levelComplete = false;
	}

	public static void StartLevel ()
	{
		time = 1;
		Time.timeScale = 1;

		isPaused = false;
		
		string randomLevel = levels [Random.Range (0, levels.Count)];


		while (playedLevels.Contains (randomLevel))
		{
			randomLevel = levels [Random.Range (0, levels.Count)];

			//se a lista de playedLevels ficar igual a de levels, reseta ela
			if (playedLevels.Count == levels.Count)
			{
				playedLevels.Clear ();
				print ("Clearing playedLevels list");
			}
		}


		//adiciona o randomLevel escolhido à lista de levels jogados, SE ele ainda não tiver sido adicionado
		if (!playedLevels.Contains (randomLevel))
			playedLevels.Add (randomLevel);

		print ("Starting " + randomLevel);
		Application.LoadLevel (randomLevel);
	}


	public static void EndLevel (bool complete)
	{
		time = 0;

		//indica se a fase foi completada com sucesso
		levelComplete = complete;

		//abre a tela de intervalo entre fases
		Application.LoadLevel ("Interval");

	}

}