using UnityEngine;
using System.Collections;

public class BlowController : MonoBehaviour {

	public SpriteRenderer dirtRenderer; //sprite da sujeira do cartucho
	public Sprite[] dirtSprites = new Sprite[6]; //sprites

	private int state = 0; //state 0 = incompleto / state 1 = completo

	private MicControlC micControl;
	private SpriteRenderer windRenderer;
	private float progress = 0;


	void Awake ()
	{
		micControl = GetComponent<MicControlC>();
		windRenderer = GetComponent<SpriteRenderer>();
	}


	void Update ()
	{
		if (state == 0)
		{
			if (micControl.loudness > 40)
			{
				windRenderer.enabled = true;
				progress += 1;
			}
			else
			{
				windRenderer.enabled = false;
			}
			
			if (progress > 25)
				dirtRenderer.sprite = dirtSprites [1];
			if (progress > 50)
				dirtRenderer.sprite = dirtSprites [2];
			if (progress > 75)
				dirtRenderer.sprite = dirtSprites [3];
			if (progress > 100)
				dirtRenderer.sprite = dirtSprites [4];
			if (progress > 125)
			{
				dirtRenderer.sprite = dirtSprites [5];
				state = 1;
			}
		}
		else if (state == 1)
		{
			Game.EndLevel (true);
			state = 3;
		}
	}
}
