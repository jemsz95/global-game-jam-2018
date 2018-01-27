using System; 
using System.Collections; 
using UnityEngine;
using CustomLibrary;

public class Test : MonoBehaviour {
    void Start() {
        var dialog = new Dialog();

        dialog.id = 0;
        dialog.paragraphs = new string[] {"Hello", "world"};
        dialog.character = Character.Ghosty;

        Debug.Log(JsonUtility.ToJson(dialog, true));
    }
}