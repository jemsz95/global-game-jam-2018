using System;

namespace CustomLibrary {
	public enum Character {
		Ghosty, Lucius, Alex, Royal
	}

	public enum NextType {
		Dialog, Question
	}

	[Serializable]
	public class Dialog {
		public int id;
		public string[] paragraphs;
		public Character characterId;
	}
}