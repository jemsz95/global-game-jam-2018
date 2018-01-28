using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

	// Use this for initialization
	public Sprite[] spriteList;

	void Start () {
		var dialogComponent = FindObjectOfType<DialogComponent>();
		dialogComponent.stateChange += OnStateChange;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnStateChange(int state) {
		
	}
}
