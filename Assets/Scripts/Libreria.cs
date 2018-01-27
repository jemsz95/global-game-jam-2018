using System; 

namespace CustomLibrary {

	[Serializable]
	public enum QuestionAnswer{Yes = 0,  No = 1} 

	[Serializable]
	public class Story {
		public int id = 0;
		public Dialog[] dialogs = null;
		public Question[] questions = null; 
	}

	[Serializable] 
	public class DialogTree{
		public Question question; 
		public Dialog dialog; 
		public DialogTree yes, no; 
		public NodeType nodeType; 

		public static DialogTree ParseStory(Story story, int node, NodeType nodeType){
			if (nodeType == NodeType.None) {
				return null; 
			}
			DialogTree root = new DialogTree ();
			if (nodeType == NodeType.Dialog) {
				root.dialog = story.dialogs [node]; 
				root.yes = ParseStory (story, root.dialog.next, root.dialog.nextType);
				root.no = root.yes;
			}else if(nodeType == NodeType.Question){
				root.question = story.questions [node]; 
				root.yes = ParseStory (story, root.question.yes, NodeType.Dialog);
				root.no = ParseStory (story, root.question.no, NodeType.Dialog);
			}

			return root; 
		}
	}

}
