using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    public Transform target;//追いかける対象-オブジェクトをインスペクタから登録できるように
	private Vector3 destination;
    public float speed = 0.1f;//移動スピード
    private Vector3 vec;

    void Start () {

    }

    void Update () {
		destination = target.position + transform.forward / 1000;
		if(Vector3.Distance(transform.position, destination) < 0.2f)
		{
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.position - transform.position), 0.3f);
		}
		else
		{
			//targetの方に少しずつ向きが変わる
        	transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (destination - transform.position), 0.3f);

        	//targetに向かって進む
        	transform.position += transform.forward * speed;
		}
    }
}
