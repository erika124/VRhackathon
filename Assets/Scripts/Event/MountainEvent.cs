using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainEvent : EventBaseObject
{
	//public Material material;
	private Status status;
	private GameObject fryingpan;
	private GameObject p_generator;
		
	enum Status{
		MOUNTAIN,
		FRYINGPAN
	}
	void Start()
	{	
		status = Status.MOUNTAIN;
		p_generator = GameObject.Find ("MountainEventManager");
	}

	
	public override void DoEvent(GameObject HitObject)
	{
		HitObject.gameObject.transform.position = this.gameObject.transform.position;
		if(HitObject.gameObject.tag == "Coin" && status == Status.MOUNTAIN){
			//coinイベント開始	
			Coin(0);
		}
		else if(HitObject.gameObject.tag == "Fryingpan" && status == Status.MOUNTAIN)
		{
			//フライパンを山に設置
			status = Status.FRYINGPAN;
			Debug.Log(status);
		}
		else if(HitObject.gameObject.tag == "Corn" && status == Status.FRYINGPAN){
			//popcornイベント開始
			Debug.Log("b");
			Invoke ("Popcorn", 2);
			Destroy(HitObject,1.5f);
		}
		else if(HitObject.gameObject.tag == "Clean"){
			Destroy(HitObject,0.5f);
			Coin(1);
			status = Status.MOUNTAIN;
			//もともとあったもの(フライパンorコインを消す)
		}
		else{
			//何も起こらない　キャラのセリフ誘発？
			Destroy(HitObject,2);
		}
	}

	private void Popcorn(){
		p_generator.GetComponent<EventManager>().Popcorn();
		
	}
	private void Coin(int pattern){
		//Debug.Log("Coin");
		p_generator.GetComponent<EventManager>().Coin(pattern);	
		Debug.Log("Coin");
	}
}
