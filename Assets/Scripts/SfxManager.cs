using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour {

	// Use this for initialization
	public AudioClip[] clipList;
	private AudioSource sfx;
	void Start () {
		var dialogComponent = FindObjectOfType<DialogComponent>();
        dialogComponent.stateChange += OnStateChange;
	}

	void Awake() {
		sfx = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnStateChange(int state) {

    }
}
