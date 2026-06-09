using UnityEngine;
public class FarmingState : BaseMinionState
{
	public FarmingState(IMinion minion) : base(minion)
	{ 
	}

	public override void OnStart(IStateRunner runner)
	{
		base.OnStart(runner);
		owner.SetPosition(new Vector3(Random.Range(-100, 0), 0, Random.Range(-100, 0)));

		Debug.Log("farming time");
	}

	public override void OnUpdate(IStateRunner runner)
	{
		base.OnUpdate(runner);
		owner.Farm();
	}

	public override void OnComplete(IStateRunner runner)
	{
		base.OnComplete(runner);
		Debug.Log("exiting farming state");
	}
}
