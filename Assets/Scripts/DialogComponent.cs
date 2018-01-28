using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomLibrary;

public class DialogComponent : MonoBehaviour {

	public TextAsset Dialogs;
	public delegate void OnStateChangeListener(int state);
	public event OnStateChangeListener stateChange;
	
	private Story story;
	private TalkingTextFunctionality DialogBox;
	private QuestionFunctionality QuestionBox; 
	private DialogTree theDialog; 
	DialogTree iterator; 

	void Start () {
		DialogBox = FindObjectOfType<TalkingTextFunctionality> (); 
		QuestionBox = FindObjectOfType<QuestionFunctionality> (); 
		story = JsonUtility.FromJson<Story>(Dialogs.text);
		theDialog =  DialogTree.ParseStory (story, 0, NodeType.Dialog); 
		iterator = theDialog; 
		DialogBox.FinishedWriting += ChangeIterator; 
		QuestionBox.OnOptionSelected += ChangeIteratorQuestion; 
		WriteNextDialog ();

	}

	void ChangeIterator(){
		iterator = iterator.yes; 
		if(iterator!=null)
			WriteNextDialog (); 
	}
	void ChangeIteratorQuestion(QuestionAnswer ans){
		if (ans == QuestionAnswer.Yes) {
			iterator = iterator.yes; 
		} else {
			iterator = iterator.no; 
		}
		if(iterator!=null && iterator.nodeType == NodeType.Dialog)
			WriteNextDialog (); 
	}

	void WriteNextDialog(){
		if (iterator.nodeType == NodeType.Dialog) {
			stateChange(iterator.dialog.id);
			DialogBox.StartWriting (iterator.dialog.paragraphs); 
		}else if(iterator.nodeType == NodeType.Question){
			QuestionBox.StartWriting (iterator.question.text, iterator.question.answers); 
		}else if(iterator.nodeType == NodeType.None){
			Debug.Log ("Time to get spooked"); 
		}
	}
}
