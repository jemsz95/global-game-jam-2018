using System;

namespace CustomLibrary {
	[Serializable]
    public class Question {
        public int id;
        public string text;
        public string[] answers;
        public int yes;
        public int no;
    }
}