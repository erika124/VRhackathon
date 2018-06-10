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
	public CanvasGroup canvasgroup;
	int count = 0;

	void Start()
	{
		playerManager.HasGameObject.DistinctUntilChanged().Subscribe(x =>
		{
			if(x != null)
			{
				canvasgroup.DOFade(1,1);
				string Message = "";
				switch(x.tag)
				{
					case "Cola":
						Message = "海にいる生き物はコーラが大好きとどこかで聞いたことがあるような…";
						break;
					case "Fryingpan":
						Message = "何かを調理するのに使えそう！あっ..でもこんなに大きなコンロなんてないですね";
						break;
					case "Mentos":
						Message = "これは魚釣りに使えそう！";
						break;
					case "Corn":
						Message = "お腹がすいてきたなー。でもこのままじゃ食べられないですね..。";
						break;
					case "Coin":
						Message = "10円玉は銅・亜鉛・すずからできているんだそうです。";
						break;
					default :
						Message = "こんにちわ";
						break;
				}
			characterView.ChangeViewText(Message);
			Observable.Timer(TimeSpan.FromSeconds(5)).Subscribe(_ =>
        	{
				characterView.MessagePanel.DOFade(0,1);
			}).AddTo(this);
			}
		});

		eventManager.eventHappen.ObserveEveryValueChanged(x => x.Value).Subscribe(x =>
		{
			characterView.MessagePanel.DOFade(1,1);
			string Message = "";
			switch(x)
			{ 
				case "CM":
					Message = "あぁ、燃えてなくなっちゃった";
					break;
				case "FM":
					Message = "お！なんかできそうだね";
					break;
				case "FCM":
					Message = "とうもろこしのタネは熱でふくら";
					break;
				case "NONE":
					Message = "何にも起きないね";
					break;
				case "CS":
					Message = "海がコーラになっちゃった";
					break;
				case "MS":
					Message = "魚はメソトスが好きかなぁ";
					break;
				case "CMS":
					Message = "大爆発だっぴ";
					break;
				case "COM":
					Message = "銅の炎色反応";
					break;
			}
			characterView.ChangeViewText(Message);
			Observable.Timer(TimeSpan.FromSeconds(5)).Subscribe(_ =>
        	{
				characterView.MessagePanel.DOFade(0,1);
			}).AddTo(this);
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