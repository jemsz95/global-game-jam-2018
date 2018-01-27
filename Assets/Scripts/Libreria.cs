using System; 

namespace CustomLibrary {
	public enum StoryStates{
		A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, Vacio
	}

	[Serializable]
	public class AFD{
		public StoryStates CurrentState; 
		StoryStates AdvanceToNextState(bool yesOrNo){
			if (CurrentState == StoryStates.A) {
				if (yesOrNo) {
					CurrentState = StoryStates.C; 
				} else {
					CurrentState = StoryStates.B; 
				}
			}
			if (CurrentState == StoryStates.B) {
				if (yesOrNo) {
					CurrentState = StoryStates.I; 
				} else {
					CurrentState = StoryStates.D; 
				}
			}
			if (CurrentState == StoryStates.C) {
				if (yesOrNo) {
					CurrentState = StoryStates.E; 
				} else {
					CurrentState = StoryStates.F; 
				}
			}
			if (CurrentState == StoryStates.D) {
				CurrentState = StoryStates.I; 
			}
			if (CurrentState == StoryStates.E) {
				if (yesOrNo) {
					CurrentState = StoryStates.F; 
				} else {
					CurrentState = StoryStates.H; 
				}
			}
			if (CurrentState == StoryStates.F) {
				CurrentState = StoryStates.G; 
			}
			if (CurrentState == StoryStates.G) {
				if (yesOrNo) {
					CurrentState = StoryStates.J; 
				} else {
					CurrentState = StoryStates.K; 
				}
			}
			if (CurrentState == StoryStates.H) {
				CurrentState = StoryStates.J; 
			}
			if (CurrentState == StoryStates.I) {
				CurrentState = StoryStates.M; 
			}
			if (CurrentState == StoryStates.J) {
				CurrentState = StoryStates.L; 
			}
			if (CurrentState == StoryStates.K) {
				CurrentState = StoryStates.R; 
			}
			if (CurrentState == StoryStates.L) {
				CurrentState = StoryStates.U; 
			}
			if (CurrentState == StoryStates.M) {
				CurrentState = StoryStates.Vacio; 
			}
			if (CurrentState == StoryStates.N) {
				CurrentState = StoryStates.Vacio; 
			}
			if (CurrentState == StoryStates.O) {
				CurrentState = StoryStates.Vacio; 
			}
			if (CurrentState == StoryStates.P) {
				CurrentState = StoryStates.Vacio; 
			}
			if (CurrentState == StoryStates.Q) {
				CurrentState = StoryStates.Vacio; 
			}
			if (CurrentState == StoryStates.R) {
				if (yesOrNo) {
					CurrentState = StoryStates.T; 
				} else {
					CurrentState = StoryStates.S; 
				}
			}
			if (CurrentState == StoryStates.S) {
				CurrentState = StoryStates.Vacio; 
			}
			if (CurrentState == StoryStates.T) {
				CurrentState = StoryStates.Vacio; 
			}
			if (CurrentState == StoryStates.U) {
				if (yesOrNo) {
					CurrentState = StoryStates.P; 
				} else {
					CurrentState = StoryStates.O; 
				}
			}
			if (CurrentState == StoryStates.Vacio) {
				//no hagas nada
			}
			return CurrentState; 
		}
	}
}
