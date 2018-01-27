using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomLibrary;

public class DialogComponent : MonoBehaviour {

	public TextAsset Dialogs;
	
	private Story story;
	private TalkingTextFunctionality tBox;

	// Use this for initialization
	void Start () {
		tBox = FindObjectOfType(typeof(TalkingTextFunctionality)) as TalkingTextFunctionality;
		story = JsonUtility.FromJson<Story>(Dialogs.text);

		tBox.StartWriting(story.dialogs[0].paragraphs);
	}

	[Serializable]
	private class Story {
		public int id = 0;
		public Dialog[] dialogs = null;
	}
}
