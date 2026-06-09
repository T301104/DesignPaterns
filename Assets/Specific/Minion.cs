using UnityEngine;


public class Minion : IMinion
{
	public int Hp { get; set; }
	public int Strength { get; set; }
	public int hunger { get; set; }
	public GameObject minionObject;
	public MinionType Miniontypes { get; set; } = MinionType.Default;
	public StateMachine stateMachine;


	public Minion(int hp, int str, GameObject objectRefrence)
	{
		Hp = hp;
		Strength = str;
		minionObject = objectRefrence;
		stateMachine = new StateMachine(this);
		stateMachine.SetState(new FarmingState(this));
		hunger = 0;
	}

	public void SetPosition(Vector3 position)
	{
		minionObject.transform.position = position;
	}

	public void Eat()
	{
		GameManager.Instance.MinionFoodChange(-hunger);
	}

	public void Mine()
	{
		GameManager.Instance.ChangeMinerals(1);

		if (Miniontypes.HasFlag(MinionType.Miner) && Random.Range(0, 2) <= 1)
		{
			GameManager.Instance.ChangeMinerals(1);
			GameManager.Instance.ChangeGems(1);
		}
	}

	public void Fight()
	{
		GameManager.Instance.ChangeEnemys(-1);

		if (Miniontypes.HasFlag(MinionType.Warrior))
		{
			GameManager.Instance.ChangeEnemys(-2);
		}
	}

	public void Farm()
	{
		GameManager.Instance.MinionFoodChange(2);

		if (Miniontypes.HasFlag(MinionType.Farmer))
		{
			GameManager.Instance.MinionFoodChange(2);
		}
	}
}
