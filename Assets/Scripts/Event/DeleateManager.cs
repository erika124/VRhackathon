using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleateManager : EventBaseObject {
	public override void DoEvent(GameObject HitObject){
		if(HitObject.gameObject.tag == "Clean"){
			Destroy(this.gameObject);
		}
	}
	
}
