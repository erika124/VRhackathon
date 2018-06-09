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
		if(HitObject.gameObject.tag == "fryingpan" && status == Status.MOUNTAIN)
		{
			//フライパンを山に設置
			status = Status.FRYINGPAN;
			//fryingpan = HitObject as GameObject;
			//fryingpan.AddComponent< MountainEvent >().status = Status.FRYINGPAN;
		}
		else if(HitObject.gameObject.tag == "corn" && status == Status.FRYINGPAN){
			//
		}
	}
}
