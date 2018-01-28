using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Zoom : MonoBehaviour {

	bool dale;
	[SerializeField] private  GameObject La_Tele;
	[SerializeField] private  Image Fade, FadeOut;
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
		Volumen =1;
		FadeOut.color = new Color (1, 1, 1, 0);

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

			if (WP > 1 && Fade.color.a<1) {
				Blank_Fade.a += 0.005f;
				Fade.color = Blank_Fade;
				FadeOut.color = Blank_Fade;
			}

			if (Fade.color.a >= 1) {
				Blank_Fade.a -= 0.005f;
				Volumen -= 0.006f;
				La_Tele.SetActive (false);
				audiosource.volume = Volumen;
				FadeOut.color = Blank_Fade;
			}
				
				
		}
			
	}

	void Update () {

		if (Input.GetKeyDown ("space"))
			dale = true;
	}
}
