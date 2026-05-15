namespace StateMachine
{
	public abstract class AState : IState
	{
		public StateEvent onSwitch { get; set; }

		public void OnComplete(IStateRunner runner) {}

		public void OnFixedUpdate(IStateRunner runner){}

		public void OnStart(IStateRunner runner){}

		public void OnUpdate(IStateRunner runner){}
	}
}