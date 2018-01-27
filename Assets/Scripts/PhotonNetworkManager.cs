using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PhotonNetworkManager : Photon.MonoBehaviour {

	[SerializeField]private Text connectText;
	[SerializeField]private Text PlayerCountTextBox; 
	[SerializeField]private GameObject Player;
	private PlayerNetwork playerNetwork; 
	public PlayerScript playerInstance; 
	public int contador;
	// Use this for initialization
	void Start () {
		playerNetwork = GameObject.FindObjectOfType<PlayerNetwork> (); 
		PhotonNetwork.ConnectUsingSettings ("0.1");
	}

	public virtual void OnJoinedLobby()
	{
		Debug.Log("we are now connected to lobby"); 
		//Join a room if this exist;
		PhotonNetwork.JoinOrCreateRoom ("New", null, null);
	} 

	public virtual void OnJoinedRoom()
	{
		playerInstance = PhotonNetwork.Instantiate (Player.name, Vector3.zero, Quaternion.identity, 0).GetComponent<PlayerScript>();

	} 

	public void OnPhotonPlayerConnected(PhotonPlayer player){
		playerNetwork.AddPlayerToList (playerInstance); 
	}
	public void OnPhotonPlayerDisconnected(PhotonPlayer player){
		playerNetwork.RemovePlayerFromList (playerInstance); 
	}

	// Update is called once per frame
	void Update () {
		PlayerCountTextBox.text = PlayerNetwork.PlayerCount + "" ; 
		connectText.text = PhotonNetwork.connectionStateDetailed.ToString ();
	}
}