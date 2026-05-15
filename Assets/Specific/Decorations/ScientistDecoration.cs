using UnityEngine;

public class ScientistDecorator : MinionDecorator
{
	public ScientistDecorator(int hp, int str) : base(hp, str) { }
	public override IMinion Decorate(IMinion minion)
	{
		Debug.Log("creating Scientist");
		minion.Miniontypes |= MinionType.Scientist;
		minion.Strength += Strength;
		minion.Hp += Hp;
		return minion;
	}
}
