using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class SceneManagerScript : MonoBehaviour {

	private GameObject MainMenu, OpenButton, HowToPlay; 
	private bool toggle; 
	public static SceneManagerScript instance; 
	public delegate void MenuEvents (); 


	void Start(){
		instance = this; 
		MainMenu = GameObject.Find ("In Game Menu").gameObject;  
		OpenButton = GameObject.Find ("Open Menu Button").gameObject; 
		HowToPlay = GameObject.Find ("How to play").gameObject; 
		ToggleInGameMenu ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.P)) {
			ToggleInGameMenu (); 
		}
	}

	public void ToggleInGameMenu(){
		toggle = !toggle; 
		if (toggle) {
			MainMenu.gameObject.SetActive (false); 
			OpenButton.gameObject.SetActive (true);
			HowToPlay.gameObject.SetActive (false); 
		} else {
			MainMenu.gameObject.SetActive (true); 
			OpenButton.gameObject.SetActive (false); 
		}
	}


	void ReturnToMainMenu(){
		SceneManager.LoadScene (0); 
	}

}
