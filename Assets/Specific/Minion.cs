using UnityEngine;


public class Minion : MonoBehaviour, IMinion
{
	public int Hp { get; set; }
	public int Strength { get; set; }
	public MinionType Miniontypes { get; set; } = MinionType.Default;
	
	public Minion(int hp, int str)
	{
		Hp = hp;
		Strength = str;
	}

	public void SetPosition(Vector3 position)
	{
		//would set minionPosition
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
		Debug.Log(Miniontypes + " Fighting with strength: " + Strength + " and Hp: " + Hp);

		if (Miniontypes.HasFlag(MinionType.Warrior))
		{
			Debug.Log("BIG ATTACK");
		}
	}

	public void Research()
	{
		Debug.Log(Miniontypes + " Researching with strength: " + Strength + " and Hp: " + Hp);

		if (Miniontypes.HasFlag(MinionType.Scientist))
		{
			Debug.Log("Ah yes, Quantum mechanics");
		}
	}
}
