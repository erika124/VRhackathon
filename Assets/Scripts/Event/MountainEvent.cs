using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainEvent : EventBaseObject
{
	//public Material material;
	private Status status;
	private GameObject fryingpan;
		
	enum Status{
		MOUNTAIN,
		FRYINGPAN
	}
	void Start()
	{	
		status = Status.MOUNTAIN;
	}

	
	public override void DoEvent(GameObject HitObject)
	{
		HitObject.gameObject.transform.position = new Vector3(0,4,0);
		if(HitObject.gameObject.tag == "Coin" && status == Status.MOUNTAIN){
			//coinイベント開始	
			Invoke ("Coin", 3);
		}
		else if(HitObject.gameObject.tag == "Fryingpan" && status == Status.MOUNTAIN)
		{
			//フライパンを山に設置
			status = Status.FRYINGPAN;
		}
		else if(HitObject.gameObject.tag == "Corn" && status == Status.FRYINGPAN){
			//popcornイベント開始
			Invoke ("Popcorn", 3);
		}
		else{
			//何も起こらない　キャラのセリフ誘発？
			Destroy(HitObject,2);
		}
	}

	private void Popcorn(){
		Debug.Log("popcorn event start!");
	}
	private void Coin(){
		Debug.Log("coin event start!");
	}
}
