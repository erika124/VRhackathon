using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterView : MonoBehaviour {
	[SerializeField]
	private Text CharacterText;

	public GameObject canvas;
	public CanvasGroup MessagePanel;
	public CanvasGroup DeletePanel;
	public Button clearSeaButton;
	public Button clearMountainButtton;
	public void ChangeViewText(string str)
	{
		CharacterText.text = str;
	}

}
