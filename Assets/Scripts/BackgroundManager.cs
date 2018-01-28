using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour {

	// Use this for initialization
	public Sprite[] spriteList;
	private Image background;
	void Start () {
		var dialogComponent = FindObjectOfType<DialogComponent>();
		dialogComponent.stateChange += OnStateChange;
	}

	void Awake() {
		background = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnStateChange(int state) {
		background.sprite = spriteList[state];
	}
}
