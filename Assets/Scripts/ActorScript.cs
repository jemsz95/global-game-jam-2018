using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorScript: MonoBehaviour {

	[SerializeField]
	public RuntimeAnimatorController[] controllers; 
	private Animator anim; 

	void Awake () {
		var dialogComponent = FindObjectOfType<DialogComponent>();
		dialogComponent.stateChange += OnStateChange;
		anim = this.gameObject.GetComponent<Animator> ();
	}

	private void OnStateChange(int state) {
		anim.runtimeAnimatorController = controllers [state];
	}


}
