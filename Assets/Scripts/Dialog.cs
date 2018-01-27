using System;

namespace CustomLibrary {
	public enum Character {
		Ghosty, Lucius, Alex, Royal
	}
		
	public enum NodeType {
		Dialog, Question, None
	}

	[Serializable]
	public class Dialog {
		public int id;
		public string[] paragraphs;
		public Character character;
		public NodeType nextType;
		public int next;
	}
}