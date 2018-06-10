using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	GameObject[] buttons;
	[SerializeField]
	private PlayerManager playerManager;

	void Start()
	{
		foreach(GameObject button in buttons)
		{
			button.GetComponent<ItemModel>().button.OnClickAsObservable().Subscribe(_ =>
			{
				GameObject obj = Resources.Load("Prefabs/" + button.gameObject.name) as GameObject;
				playerManager.GenerateObject(obj);
				this.GetComponent<CanvasGroup>().DOFade(0,1);
			});
		}
	}
}
