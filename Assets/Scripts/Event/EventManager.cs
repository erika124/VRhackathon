using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class EventManager : EventBaseObject {

public GameObject popcorn;
public GameObject magma;
public Color magmaColor;
public Color greenColor;
private Color nowmagmaColor; 
public float p_speed = 1000;
public float interval = 0.01f;
public int p_num = 20;
private Renderer _renderer;
Quaternion _rotation;

public ReactiveProperty<string> eventHappen = new ReactiveProperty<string>();


void Start()
	{

		_renderer = magma.GetComponent<Renderer>();
		_renderer.material.color = magmaColor;
		nowmagmaColor = magmaColor;
		_rotation.eulerAngles =new Vector3(0, 0, 0);
	}

//火山イベント
public void Popcorn(){
	StartCoroutine(PopcornGenerate());
}

private IEnumerator PopcornGenerate(){
	for(int i = 0; i<p_num; i++){
		GameObject p_obj = Instantiate(popcorn,this.gameObject.transform.position,_rotation);
		float random_x = Random.Range(0.5f,-0.5f);
		float random_z = Random.Range(0.5f,-0.5f);
		Vector3 fource = new Vector3(random_x,1,random_z) * p_speed; 
		p_obj.GetComponent<Rigidbody>().AddForce(fource);
		Destroy(p_obj,3.0f);
		yield return new WaitForSeconds(interval);
		}
	}
public void Coin(int pattern){
		if(pattern == 0){
			base.ColorChange(greenColor, nowmagmaColor, 5f, _renderer);
			nowmagmaColor = greenColor;
		}else{
			base.ColorChange(magmaColor, nowmagmaColor, 5f, _renderer);
			nowmagmaColor = magmaColor;
		}
	}
}
