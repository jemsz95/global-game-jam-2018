using System; 
using System.Collections; 
using UnityEngine;
using UnityEngine.UI; 

public class TalkingTextFunctionality : MonoBehaviour {
	[Range(0,0.5f)]
	public float WritingTime = 0; 

	private Text message;
	private Coroutine current;
	private Coroutine hurryUpCoroutine;
	private string[] Dialog;
	private bool hurryUp = false;

	public delegate void DialogHandler (); 
	public event DialogHandler FinishedWriting;

	void Awake(){
		message = gameObject.GetComponentInChildren<Text> (); 
		current = null; 
	}
		
	public void StartWriting(string[] dialog){
		Dialog = dialog; 
		StopWriting();
		current = StartCoroutine (WriteText()); 
	}
	public void StopWriting(){
		if (current != null) {
			StopCoroutine (current); 
		}

		if(hurryUpCoroutine != null) {
			StopCoroutine(hurryUpCoroutine);
		}
	}

	IEnumerator WriteText(){
		hurryUpCoroutine = StartCoroutine(ListenHurryUp());
		foreach(string paragraph in Dialog){
			message.text = ""; 
			hurryUp = false;//<---
			foreach(char letter in paragraph){
				message.text += letter;  
				if (!hurryUp) {
					yield return new WaitForSeconds (WritingTime * Time.deltaTime); 
				}
			} 
			StopCoroutine(hurryUpCoroutine);
			yield return StartCoroutine(WaitForSubmit());
		}
		FinishedWriting (); 

	}

	IEnumerator WaitForSubmit()
	{
		while (!Input.GetButtonDown("Submit"))
			yield return null;
	}

	IEnumerator ListenHurryUp() {
		while (true) {
			if(Input.GetButtonDown("Submit")) {
				hurryUp = true;
			}
			yield return null; 
		}
	}
}
