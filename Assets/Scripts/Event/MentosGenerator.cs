using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentosGenerator : MonoBehaviour {

public GameObject mentos;
public float m_speed = 100;
public int m_num = 20;
public float interval = 3.0f;
Quaternion _rotation;

	// Use this for initialization
	void Start () {
		_rotation.eulerAngles =new Vector3(0, 0, 0);
		Mentos();
	}
	

public void Mentos(){
	StartCoroutine(MentosGenerate());
}

private IEnumerator MentosGenerate(){

	for(int i = 0; i<m_num; i++){
		GameObject m_obj = Instantiate(mentos,this.gameObject.transform.position,_rotation);
		Vector3 fource = this.gameObject.transform.forward * m_speed; 
		m_obj.GetComponent<Rigidbody>().AddForce(fource);
		Destroy(m_obj,5.0f);
		yield return new WaitForSeconds(interval);
		}
	}

}
