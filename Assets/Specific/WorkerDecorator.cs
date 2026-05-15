using UnityEngine;

public class WorkerDecorator : MinionDecorator
{
	public WorkerDecorator(int hp, int str) : base(hp, str) { }
	public override IMinion Decorate(IMinion minion)
	{
		Debug.Log("creating Worker");
		minion.Miniontypes |= MinionType.Worker;
		minion.Strength += Strength;
		minion.Hp += Hp;
		return minion;
	}
}
