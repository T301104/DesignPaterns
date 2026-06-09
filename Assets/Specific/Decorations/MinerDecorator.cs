using UnityEngine;

public class MinerDecorator : MinionDecorator
{
	public int minerHunger = 1;
	public MinerDecorator(int hp, int str) : base(hp, str) { }
	public override IMinion Decorate(IMinion minion)
	{
		Debug.Log("creating Worker");
		minion.Miniontypes |= MinionType.Miner;
		minion.Strength += Strength;
		minion.Hp += Hp;
		minion.hunger += minerHunger;
		return minion;
	}
}
