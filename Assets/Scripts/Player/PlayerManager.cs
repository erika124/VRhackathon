using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class PlayerManager : MonoBehaviour {
	ReactiveProperty<GameObject> HasGameObject;
	public void GenerateObject(GameObject Obj)
	{
		GameObject obj = Instantiate(Obj);
	}
}
