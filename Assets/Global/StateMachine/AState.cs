
public abstract class AState : IState
{
	public StateEvent onSwitch { get; set; }

	public virtual void OnComplete(IStateRunner runner) {}

	public virtual void OnFixedUpdate(IStateRunner runner){}

	public virtual void OnStart(IStateRunner runner){}

	public virtual void OnUpdate(IStateRunner runner){}
}
