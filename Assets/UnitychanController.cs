using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanController : MonoBehaviour {
	// アニメーションするためのコンポーネント
	private Animator myAnimator;

	// Use this for initialization
	void Start () {
		// Animatorコンポーネントを取得
		this.myAnimator = GetComponent<Animator>();
		// 走るアニメーションを開始
		this.myAnimator.SetFloat("Speed", 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
