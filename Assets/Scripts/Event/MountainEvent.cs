using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainEvent : EventBaseObject
{
	//public Material material;
	private Status status;
	private GameObject fryingpan;
	private GameObject p_generator;
	private EventManager eventmanager;
	//sound類
	private AudioSource sound;
	public AudioClip pan;
	public AudioClip different;
	public AudioClip coindrop;
	public AudioClip greensound;
	public AudioClip kirakira;
		
	enum Status{
		MOUNTAIN,
		FRYINGPAN,
		COIN
	}
	void Start()
	{	
		status = Status.MOUNTAIN;
		p_generator = GameObject.Find ("MountainEventManager");
		AudioSource[] audioSources = GetComponents<AudioSource>();
 		sound = audioSources[0];
	}

	
	public override void DoEvent(GameObject HitObject)
	{
		Debug.Log("status"+status);
		HitObject.gameObject.transform.position = this.gameObject.transform.position;
		if(HitObject.gameObject.tag == "Coin" && status == Status.MOUNTAIN){
			//coinイベント開始	
			Coin(0);
			sound.PlayOneShot(coindrop);
			status = Status.COIN;
			eventmanager.eventHappen.Value = "COM";
		}
		else if(HitObject.gameObject.tag == "Fryingpan" && status == Status.MOUNTAIN)
		{
			//フライパンを山に設置
			sound.PlayOneShot(pan);
			status = Status.FRYINGPAN;
			eventmanager.eventHappen.Value = "FM";
		}
		else if(HitObject.gameObject.tag == "Corn"){
			if(status == Status.FRYINGPAN){
				//popcornイベント開始
				sound.PlayOneShot(pan);
				Invoke ("Popcorn", 2);
				Destroy(HitObject,1.5f);
				eventmanager.eventHappen.Value = "FCM";
			}else{
				sound.PlayOneShot(different);
				Destroy(HitObject,0.5f);
				eventmanager.eventHappen.Value = "CM";
			}
		}
		else if(HitObject.gameObject.tag == "Clean"){
			sound.PlayOneShot(kirakira);
			Destroy(HitObject,0.5f);
			Coin(1);
			status = Status.MOUNTAIN;
			eventmanager.eventHappen.Value = "CLEAN";
			//もともとあったもの(フライパンorコインを消す)
		}
		else{
			//何も起こらない　キャラのセリフ誘発？
			Destroy(HitObject,2);
			sound.PlayOneShot(different);
			eventmanager.eventHappen.Value = "NONE";
		}
	}

	private void Popcorn(){
		p_generator.GetComponent<EventManager>().Popcorn();
		
	}
	private void Coin(int pattern){
		//Debug.Log("Coin");
		sound.PlayOneShot(greensound);
		p_generator.GetComponent<EventManager>().Coin(pattern);	
		Debug.Log("Coin");
	}
}
