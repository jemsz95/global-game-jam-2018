using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpHowToPlay : MonoBehaviour {

	private GameObject HowToPlay; 
	private bool toggle = false; 


	// Use this for initialization
	void Awake () {
		HowToPlay = GameObject.Find ("How to play").gameObject; 
	}
		
	public void Toggle(){
		toggle = !toggle; 
		if (toggle) {
			HowToPlay.gameObject.SetActive (true); 
		} else {
			HowToPlay.gameObject.SetActive (false); 
		}
	}

}
