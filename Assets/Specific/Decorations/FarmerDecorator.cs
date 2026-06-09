using UnityEngine;

public class FarmerDecorator : MinionDecorator
{
	public int farmerHunger = 1;
	public FarmerDecorator(int hp, int str) : base(hp, str) { }
	public override IMinion Decorate(IMinion minion)
	{
		Debug.Log("creating farmer");
		minion.Miniontypes |= MinionType.Farmer;
		minion.Strength += Strength;
		minion.Hp += Hp;
		minion.hunger += farmerHunger;
		return minion;
	}
}
