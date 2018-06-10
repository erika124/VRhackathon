using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class PlayerManager : MonoBehaviour {
	public ReactiveProperty<GameObject> HasGameObject = new ReactiveProperty<GameObject>();
	public void GenerateObject(GameObject Obj)
	{
		GameObject obj = Instantiate(Obj);
	}
}
