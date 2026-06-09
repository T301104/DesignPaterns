using UnityEngine;

public class WarriorDecorator : MinionDecorator
{
	public int warriorHunger = 2;
	public WarriorDecorator(int hp, int str) : base(hp, str) { }
	public override IMinion Decorate(IMinion minion)
	{
		Debug.Log("creating Warrior");
		minion.Miniontypes |= MinionType.Warrior;
		minion.Strength += Strength;
		minion.Hp += Hp;
		minion.hunger += warriorHunger;
		return minion;
	}
}
