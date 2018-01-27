using System;

namespace CustomLibrary {
	public enum Character {
		Ghosty, Lucias, Alexis, Royal
	}

	[Serializable]
	public class Dialog {
		public int id;
		public string[] paragraphs;
		public Character character;
	}
}