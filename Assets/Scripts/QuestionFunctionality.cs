using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using CustomLibrary; 

public class QuestionFunctionality : MonoBehaviour {

	private Text message;
	private Coroutine current;
	private Coroutine hurryUpCoroutine;
	private string question;
	private string[] options;
	private bool hurryUp = false;
	private QuestionAnswer selected;
	private AudioSource audioSrc;
	
	public delegate void OptionHandler(QuestionAnswer ans);
	public event OptionHandler OnOptionSelected;
	public AudioClip TextClip;
	public AudioClip TextTrailClip;

	// Use this for initialization
	void Awake () {
		message = gameObject.GetComponentInChildren<Text> ();
		audioSrc = GetComponent<AudioSource>();
	}
	
	public void StartWriting(string question, string[] options){
		this.question = question;
		this.options = options;
		StopWriting (); 
		current = StartCoroutine (WriteText()); 
	}
	
	public void StopWriting(){
		if (current != null) {
			StopCoroutine (current);
			current = null; 
		}

		if(hurryUpCoroutine != null) {
			StopCoroutine(hurryUpCoroutine);
			hurryUpCoroutine = null; 
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

	IEnumerator WaitForOption() {
		selected = QuestionAnswer.Yes;
		yield return new WaitForEndOfFrame(); 
		message.text += "\n"+"<b>" + options[0] + "</b>" + "\n" + options[1];
		while(!Input.GetButtonDown("Submit")) {
			if(Input.GetButtonDown("Vertical") || Input.GetButtonDown("Horizontal")) {
				selected = selected == QuestionAnswer.Yes ? QuestionAnswer.No : QuestionAnswer.Yes;
				message.text = question + "\n";
				if(selected == QuestionAnswer.Yes) {
					message.text += "<b>" + options[0] + "</b>" + "\n" + options[1];
				} else {
					message.text += options[0] + "\n" + "<b>" + options[1] + "</b>";
				}
			}
			yield return null;
		}
		OnOptionSelected(selected);
	}

	IEnumerator WriteText() {
		hurryUpCoroutine = StartCoroutine (ListenHurryUp ()); 
		message.text = "";
		playAudio();
		foreach(char letter in question){
			message.text += letter;  
			yield return new WaitForSeconds(0); 
		}
		StopCoroutine (hurryUpCoroutine); 
		stopAudio();
		yield return StartCoroutine(WaitForOption());
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
