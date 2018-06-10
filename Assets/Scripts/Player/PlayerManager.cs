using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class PlayerManager : MonoBehaviour {
	public ReactiveProperty<GameObject> HasGameObject = new ReactiveProperty<GameObject>();

	public LaserPointer laserPointer;
	public void GenerateObject(GameObject Obj)
	{
		GameObject obj = Instantiate(Obj, laserPointer.Pointer.transform.position, transform.rotation);
		HasGameObject.Value = obj;
		laserPointer.target_obj = obj;
		laserPointer.hold_flag = true;
	}
}
