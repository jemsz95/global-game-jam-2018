using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class Lobby : MonoBehaviour {
	public string BaseUrl = null;

	private Transmission transmission;
	private bool downloading;

	public IEnumerable Get(string path) {
		var req = UnityWebRequest.Get(BaseUrl + path);
		downloading = true;

		yield return req.SendWebRequest();

		if(req.isNetworkError || req.isHttpError) {
			Debug.Log(req.error);
		} else {
			var encoder = new UTF8Encoding();
			var data = req.downloadHandler.data;
			var json = encoder.GetString(data);
			transmission = JsonUtility.FromJson<Transmission>(json);
		}

		downloading = false;
	}

	public IEnumerable Post(string path, string data) {
		yield return null;
	}

}
