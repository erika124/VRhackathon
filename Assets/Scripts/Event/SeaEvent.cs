using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaEvent : EventBaseObject
{
	public Material material;
	private Status status;
	enum Status{
		SEA,
		COLA
	}

	void Start()
	{
		status = Status.SEA;
	}
	
	public override void DoEvent(GameObject HitObject)
	{
		if(HitObject.gameObject.tag == "Cola" && status == Status.SEA)
		{
			//マテリアルの色を徐々に変化する
			ColorChange(0); //cola寄り
			status = Status.COLA;
		}
		else if(HitObject.gameObject.tag == "Mentos" && status == Status.COLA){
			//イベントスタート
			GenerateBubble();
		}
		else{
			//何も起こらない　キャラのセリフ誘発？
			Destroy(HitObject,2);
		}
	}

	//朝になったらにマテリアルの色が徐々に元になっていくようにセットをする
	private void ColorChange(int pattern){
		if(pattern == 0){
			//コーラに寄ってく
		}else{
			//普通の海に戻る
		}
	}
	//泡を発生する
	private void GenerateBubble()
	{
		//カメラが揺れる
	}
}
