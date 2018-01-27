using System; 
using System.Collections; 
using UnityEngine;
using UnityEngine.UI; 

public class TalkingTextFunctionality : MonoBehaviour {
	[Range(0,0.5f)]
	public float WritingTime = 0; 

	private Text message; 
	private Coroutine current; 
	private string[] Dialog; 
	private bool hurryUp; 

	void Awake(){
		message = this.gameObject.GetComponentInChildren<Text> (); 
		current = null; 
		hurryUp = false; 
	}
		
	public void StartWriting(string[] dialog){
		Dialog = dialog; 
		current = null; 
		current = StartCoroutine (WriteText()); 
	}
	public void StopWriting(){
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
					yield return new WaitForSeconds (WritingTime); 
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
