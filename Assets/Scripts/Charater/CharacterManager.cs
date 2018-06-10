using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;
using System;

public class CharacterManager : MonoBehaviour {
	[SerializeField]
	PlayerManager playerManager;

	[SerializeField]
	CharacterView characterView;

	[SerializeField]
	EventManager eventManager;

	void Start()
	{
		playerManager.HasGameObject.ObserveEveryValueChanged(x => x.Value.gameObject.tag).Subscribe(x =>
		{
			characterView.MessagePanel.DOFade(1,1);
			string Message = "";
			switch(x)
			{
				case "cola":
					Message = "魚もコーラ好きなのかな";
					break;
				case "fryingpan":
					Message = "料理につかいそうだね";
					break;
				case "mentos":
					Message = "";
					break;
				case "corn":
					Message = "お腹がすいてきちゃった";
					break;
				case "coin":
					Message = "お金って大事だよね";
					break;
			}
			characterView.ChangeViewText(Message);
			Observable.Timer(TimeSpan.FromSeconds(5)).Subscribe(_ =>
        	{
				characterView.MessagePanel.DOFade(0,1);
			}).AddTo(this);
		});

		eventManager.eventHappen.ObserveEveryValueChanged(x => x.Value).Subscribe(x =>
		{
			string Message = "";
			switch(x)
			{
				case "aa":
					Message = "ポップコーン";
					break;
			}
			characterView.ChangeViewText(Message);
		});

		characterView.clearSeaButton.OnCancelAsObservable().Subscribe(_ =>
		{
			characterView.DeletePanel.DOFade(0,1);
			GenerateSeaItem();
		});

		characterView.clearMountainButtton.OnCancelAsObservable().Subscribe(_ =>
		{
			characterView.DeletePanel.DOFade(0,1);
			GenerateMountainItem();	
		});

 	}

	//キャラクターをタッチしたらCanvasを表示
	public void TouchCharacter()
	{
		characterView.DeletePanel.DOFade(1,1);
	}

	//海を初期化
	void GenerateSeaItem()
	{
		//パーティクル
		//Instationate
	}

	//山を初期化
	void GenerateMountainItem()
	{

	}

}