using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour {
	[SerializeField]
	private Text CharacterText;

	public Canvas canvas;
	public Button clearSeaButton;
	public Button clearMountainButtton;
	void ChangeViewText(string str)
	{
		CharacterText.text = str;
	}
}
