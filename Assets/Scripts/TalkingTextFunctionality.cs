using System; 
using System.Collections; 
using UnityEngine;
using UnityEngine.UI; 

public class TalkingTextFunctionality : MonoBehaviour {

	private Text message; 
	private Coroutine current; 
	[Range(0,10)]
	private float WrittingTime = 0; 
	private string[] Dialog; 
	private bool hurryUp; 

	void Awake(){
		message = this.gameObject.GetComponentInChildren<Text> (); 
		current = null; 
		hurryUp = false; 
	}
		
	public void StartWritting(string[] dialog){
		Dialog = dialog; 
		current = null; 
		current = StartCoroutine (WriteText()); 
	}
	public void StopWritting(){
		if (current != null) {
			StopCoroutine (current); 
		}
	}
	void Update(){
		if (Input.GetButtonDown("Submit")) {
			hurryUp = true; 
		}
	}

	IEnumerator WriteText(){
		foreach(string paragraph in Dialog){
			message.text = ""; 
			hurryUp = false;//<---
			foreach(char letter in paragraph){
				message.text += letter; 
				if (!hurryUp) {
					yield return new WaitForSeconds (WrittingTime); 
				}
			} 
			yield return StartCoroutine(WaitForSubmit());
		}
	}

	IEnumerator WaitForSubmit()
	{
		while (!Input.GetButtonDown("Submit"))
			yield return null;
	}


}
