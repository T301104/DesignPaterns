using UnityEngine;


public class Minion : IMinion
{
	public int Hp { get; set; }
	public int Strength { get; set; }
	public MinionType Miniontypes { get; set; } = MinionType.Default;
	
	public Minion(int hp, int str)
	{
		Hp = hp;
		Strength = str;
	}

	public void Mine()
	{
		Debug.Log(Miniontypes + " Mining with strength: " + Strength + " and Hp: " + Hp);

		if (Miniontypes.HasFlag(MinionType.Worker))
		{
			Debug.Log("Finding Gems!");
		}
	}

	public void Fight()
	{
	}

	public void Research()
	{
	}
}
