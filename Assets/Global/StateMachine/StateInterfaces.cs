using UnityEngine;

namespace StateMachine
{
	public delegate void StateEvent(IState state);

	public interface IState
	{
		void OnStart(IStateRunner runner);
		void OnUpdate(IStateRunner runner);
		void OnFixedUpdate(IStateRunner runner);
		void OnComplete(IStateRunner runner);

		StateEvent onSwitch { get; set; }
	}

	public interface IStateRunner
	{
		
	}

}