using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomLibrary;

public class DialogComponent : MonoBehaviour {

	public TextAsset Dialogs;
	
	private Story story;
	private TalkingTextFunctionality DialogBox;
	private QuestionFunctionality QuestionBox; 
	private DialogTree theDialog; 

	// Use this for initialization
	void Start () {
		DialogBox = FindObjectOfType<TalkingTextFunctionality> (); 
		QuestionBox = FindObjectOfType<QuestionFunctionality> ();  
		story = JsonUtility.FromJson<Story>(Dialogs.text);
		theDialog =  DialogTree.ParseStory (story, 0, NodeType.Dialog); 
		DialogTree iterator = theDialog; 
		while (iterator != null) {
			if (iterator.nodeType == NodeType.Dialog) {
				DialogBox.StartWriting (iterator.dialog.paragraphs); 
			}else if(iterator.nodeType == NodeType.Question){
				QuestionBox.StartWriting (iterator.question.text, iterator.question.answers); 
			}else if(iterator.nodeType == NodeType.None){
				Debug.Log ("Time to get spooked"); 
			}

		}
	}
}
