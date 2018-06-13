using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNatureManager : EventBaseObject {

	Rigidbody i_Rigidbody;

	void Start(){
		i_Rigidbody = GetComponent<Rigidbody>();
	}

	public override void DoEvent(GameObject HitObject){
		if(HitObject.gameObject.tag == "Clean"){
			Destroy(this.gameObject);
		}
		if(HitObject.gameObject.tag != "Untagged" && HitObject.gameObject.tag != this.gameObject.tag){
			StartCoroutine(Freeze());
		}
	}

	private IEnumerator Freeze(){
		yield return new WaitForSeconds(5.0f);
		i_Rigidbody.isKinematic = true;
	}
	
}
