using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EventBaseObject : MonoBehaviour
{
	public virtual void DoEvent(GameObject HitObject){}

	public void OnCollisionEnter(Collision other)
	{
		DoEvent(other.gameObject);
	}
	public void OnTriggerEnter(Collider other)
	{
		DoEvent(other.gameObject);
	}
}
