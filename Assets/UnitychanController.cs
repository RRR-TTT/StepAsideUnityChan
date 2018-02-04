using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanController : MonoBehaviour {
	// アニメーションするためのコンポーネント
	private Animator myAnimator;
	// Unityちゃんを移動させるコンポーネントを入れる
	private Rigidbody myRigidbody;
	// 前進するための力
	private float forwardForce = 800.0f;

	// Use this for initialization
	void Start () {
		// Animatorコンポーネントを取得
		this.myAnimator = GetComponent<Animator>();
		// 走るアニメーションを開始
		this.myAnimator.SetFloat("Speed", 1.0f);
		// Rigidbodyコンポーネントを取得
		this.myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// Unityちゃんに前方向の力を加える
		this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);
	}
}
