using UnityEngine;
using System.Collections;

public class BlowController : MonoBehaviour {

	public GameObject wind;
	public Vector3 timerScale; //BARRA DE TEMPO

	public SpriteRenderer dirtRenderer; //sprite da sujeira do cartucho
	public Sprite[] dirtSprites = new Sprite[6]; //sprites

	private int state = 0; //state 0 = incompleto / state 1 = completo

	private MicControlC micControl;
	private SpriteRenderer windRenderer;
	private float progress = 0;


	void Awake ()
	{
		micControl = wind.GetComponent<MicControlC>();
		windRenderer = wind.GetComponent<SpriteRenderer>();
	}


	void Update ()
	{
		timerScale = GameObject.Find ("Timer").transform.localScale;

		if (state == 0) //OBJETIVO INCOMPLETO
		{
			if (micControl.loudness > 30) //SE O BARULHO DO MICROFONE FOR MAIOR QUE 30
			{
				windRenderer.enabled = true; //MOSTRA O VENTO
				progress += 1; //ADICIONA 1 AO MEDIDOR DE PROGRESSO
			}
			else //CASO CONTRARIO
			{
				windRenderer.enabled = false; // OCULTA O VENTO
			}

			if (progress > 25) //MUDA O SPRITE DE ACORDO COM O MEDIDOR DE PROGRESSO
				dirtRenderer.sprite = dirtSprites [1];
			if (progress > 50)
				dirtRenderer.sprite = dirtSprites [2];
			if (progress > 75)
				dirtRenderer.sprite = dirtSprites [3];
			if (progress > 100) //AO ATINGIR 100 DE PROGRESSO
			{
				dirtRenderer.sprite = dirtSprites [4];
				
				state = 1; //COMPLETOU OBJETIVO
			}
		}
		else if (state == 1) //OBJETIVO COMPLETO
		{
			animation.Play ("Blow-end"); //ANIMACAO DO CARTUCHO ENTRANDO NO CONSOLE
			state = 2; //ESTADO 2, FIM
		}

		if (timerScale.x <= 0) //SE O TEMPO TIVER ACABADO
		{
			animation.Play ("Blow-end"); //ANIMACAO DO CARTUCHO ENTRANDO NO CONSOLE
			state = 2; //ESTADO 2, FIM
		}
	}

	public void EndAnimation ()
	{
		if (progress > 125)
		{
			//ANIMACAO DE SUCESSO
			Game.EndLevel (true);
		}
		else
		{
			//ANIMACAO DE FRACASSO
			Game.EndLevel (false);
		}
	}
}
