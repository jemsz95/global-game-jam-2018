using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreditsScript : MonoBehaviour {

	private GameObject CreditsArt, CreditsProg; 
	private bool toggle; 

	void Start(){
		CreditsArt = GameObject.Find ("CreditsArt");
		CreditsProg = GameObject.Find ("CreditsProg"); 
		toggle = false; 
		StartCoroutine (CreditsToggle ()); 
	}



	IEnumerator CreditsToggle(){
		CreditsProg.SetActive (false); 
		while (true) {
			toggle = !toggle; 
			if(toggle){
				CreditsArt.SetActive (true); 
				CreditsProg.SetActive (false); 
			}else{
				CreditsArt.SetActive (false); 
				CreditsProg.SetActive (true);
			}
			yield return new WaitForSeconds (2.7f);
		}


	}
}
