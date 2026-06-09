using UnityEngine;
public class MiningState : BaseMinionState
{
	public MiningState (IMinion minion) : base (minion)
	{	}
	public override void OnStart(IStateRunner runner)
	{
		base.OnStart(runner);
		owner.SetPosition(new Vector3 (Random.Range(-100, 0), 0, Random.Range(0, 100)));
		Debug.Log("I have to go to work today");
	}

	public override void OnUpdate(IStateRunner runner)
	{
		base.OnUpdate(runner);
		owner.Mine();
	}

	public override void OnComplete(IStateRunner runner)
	{
		base.OnComplete(runner);
		Debug.Log("exiting work state");
	}
}
