using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oshima : MonoBehaviour {

	public GameObject fryingpan;
	public GameObject cola;
	public GameObject corn;
	public GameObject mentos;
	public GameObject coin;

	

	Quaternion _rotation;
	// Use this for initialization
	void Start () {
		_rotation.eulerAngles =new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F)){
			GameObject f = Instantiate(fryingpan,new Vector3(-2,10,0),_rotation);
			}
		else if(Input.GetKeyDown(KeyCode.P)){
			GameObject p = Instantiate(corn,new Vector3(-2,10,0),_rotation);
			}
		else if(Input.GetKeyDown(KeyCode.C)){
			GameObject c = Instantiate(coin,new Vector3(-2,10,0),_rotation);
			}
		else if(Input.GetKeyDown(KeyCode.K)){
			GameObject k = Instantiate(cola,new Vector3(-2,10,0),_rotation);
			}
		else if(Input.GetKeyDown(KeyCode.M)){
			GameObject m = Instantiate(mentos,new Vector3(-2,10,0),_rotation);
			}
	}
}
