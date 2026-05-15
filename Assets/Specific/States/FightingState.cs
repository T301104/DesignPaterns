using UnityEngine;
public class FightingState : AState
{
	IMinion runnerMinion;

	public FightingState(IMinion minion)
	{
		runnerMinion = minion;
	}
	public override void OnStart(IStateRunner runner)
	{
		base.OnStart(runner);
		Debug.Log("Combat time!");
	}

	public override void OnUpdate(IStateRunner runner)
	{
		base.OnUpdate(runner);
		runnerMinion.Fight();
	}

	public override void OnComplete(IStateRunner runner)
	{
		base.OnComplete(runner);
		Debug.Log("exiting Fight state");
	}
}
