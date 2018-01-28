using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuManager : MonoBehaviour {

	public void StartNewGame(){
		SceneManager.LoadScene (1); 
	}

	public void ContinueGame(){

	}

	public void GoToCredits(){
		SceneManager.LoadScene (2); 
	}
	public void QuitGame(){
		Application.Quit (); 
	}

}
