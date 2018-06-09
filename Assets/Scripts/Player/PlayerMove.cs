using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove: MonoBehaviour {
	Rigidbody m_Rigidbody;

	    // Use this for initialization
	    void Start () {
	        // 自分のRigidbodyを取ってくる
	        m_Rigidbody = GetComponent<Rigidbody>();
	    }

	    // Update is called once per frame
	    void FixedUpdate () {
	        float x = 0.0f;
	        float z = 0.0f;
	        Vector2 touchPadPt = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

	        if (touchPadPt.x > 0.5 && -0.5 < touchPadPt.y && touchPadPt.y < 0.5) //右方向
	        {
	            transform.Rotate(new Vector3(0.0f, 0.5f, 0.0f)); // 十字キーで首を左右に回す
	            x += 0.2f;
	        }
	        if (touchPadPt.x < -0.5 && -0.5 < touchPadPt.y && touchPadPt.y < 0.5) //左方向
	        {
	            transform.Rotate(new Vector3(0.0f, -0.5f, 0.0f));         // 十字キーで首を左右に回す
	            x -= 0.2f;
	        }
	        if (touchPadPt.y > 0.2 && -0.5 < touchPadPt.x && touchPadPt.x < 0.5) //上方向
	        {
	            z += 2.0f;
	        }
	        if (touchPadPt.y < -0.5 && -0.5 < touchPadPt.x && touchPadPt.x < 0.5) //下方向
	        {
	            z -= 2.0f;
	        }

	        m_Rigidbody.velocity = z * transform.forward + x * transform.right;



	    }
}
