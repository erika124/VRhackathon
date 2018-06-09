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
		if(HitObject.gameObject.tag == "Mentosu" && status == Status.SEA)
		{
			//マテリアルの色を徐々に変化する
			GenerateBubble();
			//30秒後にマテリアルの色が徐々に元になっていくようにセットをする
		}
	}

	//泡を発生する
	private void GenerateBubble()
	{
		//カメラが揺れる
	}
}
