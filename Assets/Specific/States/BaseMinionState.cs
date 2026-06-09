using UnityEngine;

public class BaseMinionState : AState<IMinion>
{
	public BaseMinionState(IMinion minion) : base(minion)
	{
	}

	public override void OnStart(IStateRunner runner)
	{
		base.OnStart(runner);
	}

	public override void OnUpdate(IStateRunner runner)
	{
		base.OnUpdate(runner);
		owner.Eat();
	}

	public override void OnComplete(IStateRunner runner)
	{
		base.OnComplete(runner);
	}
}
