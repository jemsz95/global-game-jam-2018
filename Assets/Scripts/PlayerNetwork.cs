using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerNetwork : MonoBehaviour {

	private PhotonView photonView;
	private List<PlayerScript> players; 
	public static int PlayerCount; 


	// Use this for initialization
	void Start () 
	{	
		PlayerCount = players.Count; 
		photonView = this.gameObject.GetComponent<PhotonView> ();
	}

	public void AddPlayerToList(PlayerScript playerToAdd){
		players.Add (playerToAdd); 
		PlayerCount = players.Count; 
	}
	public void RemovePlayerFromList(PlayerScript playerToRemove){
		players.Remove (playerToRemove); 
		PlayerCount = players.Count; 
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			stream.SendNext (PlayerCount);
			stream.SendNext (players); 
		} else if (stream.isReading) {
			PlayerCount = (int)stream.ReceiveNext();
			players = (List<PlayerScript>)stream.ReceiveNext (); 
		}
	}

}