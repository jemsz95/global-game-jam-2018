using System; 
using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TalkingTextFunctionality : MonoBehaviour {
	private Text message;
	private Coroutine current;
	private Coroutine hurryUpCoroutine;
	private string[] Dialog;
	private bool hurryUp = false;
	private AudioSource audioSrc;

	public delegate void DialogHandler (); 
	public event DialogHandler FinishedWriting;
	public AudioClip TextClip;
	public AudioClip TextTrailClip;

	void Awake() {
		message = gameObject.GetComponentInChildren<Text> ();
		audioSrc = GetComponent<AudioSource>();
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

	private void playAudio() {
		audioSrc.loop = true;
		audioSrc.clip = TextClip;
		audioSrc.Play();
	}
	private void stopAudio() {
		audioSrc.Stop();
		audioSrc.loop = false;
		audioSrc.clip = TextTrailClip;
		audioSrc.Play();
	}

	IEnumerator WriteText(){
		hurryUpCoroutine = StartCoroutine(ListenHurryUp());
		foreach(string paragraph in Dialog){
			playAudio();
			message.text = ""; 
			hurryUp = false;//<---
			foreach(char letter in paragraph){
				message.text += letter;  
				if (!hurryUp) {
					yield return new WaitForEndOfFrame(); 
				}
			} 
			StopCoroutine(hurryUpCoroutine);
			stopAudio();
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
