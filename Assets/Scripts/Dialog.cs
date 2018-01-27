using System;

namespace CustomLibrary {
	public enum Chacacter {
		Ghosty, Lucius, Alex, Royal
	}

	[Serializable]
	public class Dialog {
		public int id;
		public string[] paragraphs;
		public Chacacter characterId;
	}
}