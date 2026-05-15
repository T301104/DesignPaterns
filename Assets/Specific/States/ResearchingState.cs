using UnityEngine;
public class ResearchingState : AState
{
	IMinion runnerMinion;

	public ResearchingState(IMinion minion)
	{
		runnerMinion = minion;
	}
	public override void OnStart(IStateRunner runner)
	{
		base.OnStart(runner);
		Debug.Log("research time");
	}

	public override void OnUpdate(IStateRunner runner)
	{
		base.OnUpdate(runner);
		runnerMinion.Research();
	}

	public override void OnComplete(IStateRunner runner)
	{
		base.OnComplete(runner);
		Debug.Log("exiting research state");
	}
}
