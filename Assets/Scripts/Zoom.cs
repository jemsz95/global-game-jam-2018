using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Zoom : MonoBehaviour {

	bool dale;
	[SerializeField] private  GameObject La_Tele, WaveVision;
	[SerializeField] private  Image Fade;
	float YP, XP, WP, HP, Volumen;
	Color Blank_Fade;
	[SerializeField] private AudioClip static_tv;
	AudioSource audiosource;

	// Use this for initialization
	void Start () {
		dale = false;
		YP = La_Tele.GetComponent<Camera> ().rect.y;
		XP = La_Tele.GetComponent<Camera> ().rect.x;
		WP = La_Tele.GetComponent<Camera> ().rect.width;
		HP = La_Tele.GetComponent<Camera> ().rect.height;
		Fade.color=new Color(1, 1, 1, 0);
		Blank_Fade = new Color (1, 1, 1, 0);
		audiosource = this.GetComponent<AudioSource> ();
		audiosource.loop = true;
		Volumen =1;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!audiosource.isPlaying)
			audiosource.PlayOneShot (static_tv, 0.1f);
		
		if (dale == true) {
			audiosource.volume =WP;
			YP -= 0.001f;
			XP -= 0.004f;
			WP += 0.005f;
			HP += 0.005f;
			La_Tele.GetComponent<Camera> ().rect=new Rect(XP, YP, WP, HP);

			if (WP > 1f && WP < 2f) {
				Blank_Fade.a += 0.007f;
				Fade.color = Blank_Fade;
				//FadeOut.color = Blank_Fade;
			}

			if (WP > 1.8f) {
				Blank_Fade.a -= 0.008f;
				Volumen -= 0.006f;
				La_Tele.SetActive (false);
				audiosource.volume = Volumen;
				Fade.color = Blank_Fade;
			}

			if(WP>2f)
			WaveVision.GetComponent<WaveVision> ().ON = true;
		}
			
	}

	void Update () {

		if (Input.GetKeyDown ("space"))
			dale = true;
	}
}
