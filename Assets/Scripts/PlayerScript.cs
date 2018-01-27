using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomLibrary; 

public class PlayerScript : MonoBehaviour {

	private AFD myAFD; 

	void UpdateMyStory(bool decisionOutcome){
		myAFD.AdvanceToNextState (decisionOutcome); 
	}


}
