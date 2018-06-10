using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
	public int Id;
	private GameObject awa;
	float angle = 0;
    float range = 4f;
    float yspeed = 0.05f;

	void Start(){
		awa = this.gameObject.transform.GetChild(0).gameObject;
		awa.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		StartCoroutine(movingbubble(Id));
	}
	private	IEnumerator movingbubble(int id){
		yield return new WaitForSeconds(id);
		awa.SetActive(true);
		Vector3 v = transform.position;
        v.y = Mathf.Sin (angle) * range;
        angle += yspeed;
        transform.position = v;
	}
}
