using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaEvent : EventBaseObject
{
	//public Material material;
	//public GameObject camera;
	public GameObject bubbles;
	public int b_turn = 5;
	public float interval = 2.0f;
	public Color seaColor;
	public Color colaColor;
	private Color nowseaColor; 
	private Status status;
	private Renderer _renderer;
	private EventManager eventmanager;

	//sound類
	private AudioSource sound;
	public AudioClip seadrop;
	public AudioClip bubble;
	public AudioClip kirakira;
	
	
	enum Status{
		SEA,
		COLA
	}

	void Start()
	{
		status = Status.SEA;
		_renderer = this.GetComponent<Renderer>();
		_renderer.material.color = seaColor;
		nowseaColor = seaColor;
		bubbles.SetActive(false);
		AudioSource[] audioSources = GetComponents<AudioSource>();
 		sound = audioSources[0];
	}
	
	public override void DoEvent(GameObject HitObject)
	{
		if(HitObject.gameObject.tag == "Cola" && status == Status.SEA)
		{
			sound.PlayOneShot(seadrop);
			Destroy(HitObject,0.5f);
			//マテリアルの色を徐々に変化する
			Change(0); //cola寄り
			status = Status.COLA;
			eventmanager.eventHappen.Value = "CS";
		}
		else if(HitObject.gameObject.tag == "Mentos"){
			sound.PlayOneShot(seadrop);
			if(status == Status.COLA){
				Destroy(HitObject,0.5f);
				//イベントスタート
				Debug.Log("bubble");
				StartCoroutine(GenerateBubble());
				eventmanager.eventHappen.Value = "CMS";
			}else{
				eventmanager.eventHappen.Value = "MS";
			}
		}
		else if(HitObject.gameObject.tag == "Clean"){
			sound.PlayOneShot(kirakira);
			Destroy(HitObject,0.5f);
			status = Status.SEA;
			Change(1);
			eventmanager.eventHappen.Value = "CLEAN";
		}
		else{
			//何も起こらない　キャラのセリフ誘発？
			if(HitObject.gameObject.tag != "Untagged"){
			sound.PlayOneShot(seadrop);
			Destroy(HitObject,2);
			eventmanager.eventHappen.Value = "NONE";
			}
		}
	}

	public void Change(int pattern){
		if(pattern == 0){
			//コーラに寄ってく
			base.ColorChange(colaColor, nowseaColor, 10f, _renderer);
			nowseaColor = colaColor;
		}else{
			//普通の海に戻る
			base.ColorChange(seaColor, nowseaColor, 10f, _renderer);
			nowseaColor = seaColor;
		}
	}
	//泡を発生する
	private IEnumerator GenerateBubble()
	{
		//カメラが揺れる
		//iTween.ShakePosition(camera.gameObject,iTween.Hash("x",0.3f,"y",0.3f,"time",10f));
		yield return new WaitForSeconds(2f);
		sound.PlayOneShot(bubble);
		bubbles.SetActive(true);
		//yield return 0;
		
	}
}
