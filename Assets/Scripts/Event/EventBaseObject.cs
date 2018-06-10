using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EventBaseObject : MonoBehaviour
{
	public virtual void DoEvent(GameObject HitObject){}

	//マテリアルの色が徐々に変わる
	private IEnumerator ChangeColor(Color toColor, Color changeColor, float duration, Renderer _renderer) {
    Color fromColor = changeColor;
    float startTime = Time.time;
    float endTime = Time.time + duration;
    float marginR = toColor.r - fromColor.r;
    float marginG = toColor.g - fromColor.g;
    float marginB = toColor.b - fromColor.b;

    while (Time.time < endTime) {
        changeColor.r = changeColor.r + (Time.deltaTime / duration) * marginR;
        changeColor.g = changeColor.g + (Time.deltaTime / duration) * marginG;
        changeColor.b = changeColor.b + (Time.deltaTime / duration) * marginB;
		_renderer.material.color = changeColor;
        yield return 0;
    }
    yield break;
}

	public virtual　void ColorChange(Color toColor, Color changeColor, float duration, Renderer _renderer){
			Debug.Log("base");
			StartCoroutine(ChangeColor(toColor, changeColor, duration, _renderer));
	}

	public void OnCollisionEnter(Collision other)
	{
		DoEvent(other.gameObject);
	}
	public void OnTriggerEnter(Collider other)
	{
		DoEvent(other.gameObject);
	}
}
