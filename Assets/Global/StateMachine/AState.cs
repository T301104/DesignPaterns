
public abstract class AState<T> : IState
{
	protected T owner;

	protected AState(T owner)
	{
		this.owner = owner;
	}

	 public StateEvent onSwitch { get; set; }

	public virtual void OnComplete(IStateRunner runner) {}

	public virtual void OnFixedUpdate(IStateRunner runner){}

	public virtual void OnStart(IStateRunner runner){}

	public virtual void OnUpdate(IStateRunner runner){}
}
