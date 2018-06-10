using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(0,0.01f,0);
	}
}
