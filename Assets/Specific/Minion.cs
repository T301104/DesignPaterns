using UnityEngine;

public class Minion : IMinion
{
	public int Hp { get; set; }
	public int Strength { get; set; }
	public MinionType Miniontypes { get; set; } = MinionType.Default;
	
	public Minion (int hp, int str)
	{
		Hp = hp;
		Strength = str;
	}

	public void Work()
	{
		Debug.Log(Miniontypes + " working hard with strength: " + Strength + " and Hp: " + Hp);
	}
}
