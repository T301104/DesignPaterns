using UnityEngine;
public class WorkingState : AState
{
	IMinion runnerMinion;

	public WorkingState (IMinion minion)
	{
		runnerMinion = minion;
	}
	public override void OnStart(IStateRunner runner)
	{
		base.OnStart(runner);
		Debug.Log("I have to go to work today");
	}

	public override void OnUpdate(IStateRunner runner)
	{
		base.OnUpdate(runner);
		runnerMinion.Mine();
	}

	public override void OnComplete(IStateRunner runner)
	{
		base.OnComplete(runner);
		Debug.Log("exiting work state");
	}
}
