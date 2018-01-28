using UnityEngine;
using System.Collections;

public class WaveVision : MonoBehaviour {

	[SerializeField] private  GameObject Camara_Principal;
	public bool ON;
	float Down;


	// Use this for initialization
	void Start () {

		Camara_Principal.GetComponent<CameraFilterPack_TV_50> ().enabled = false;
		Camara_Principal.GetComponent<CameraFilterPack_Real_VHS> ().enabled = false;
		Down = 1;

	
	}
	
	// Update is called once per frame
	public void Toggle () {

		if (ON) {
			if(Down>0)
			Down -= 0.005f;

			if (Down > 0.09f) {
				Camara_Principal.GetComponent<CameraFilterPack_TV_50> ().enabled = true;
				Camara_Principal.GetComponent<CameraFilterPack_Real_VHS> ().enabled = true;
			}
			Camara_Principal.GetComponent<CameraFilterPack_TV_50> ().Fade = Down;
		}
	
	}
}
