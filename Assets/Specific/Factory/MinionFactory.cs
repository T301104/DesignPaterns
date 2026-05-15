using UnityEngine;

public class WorkerFactory : IFactory<Minion>
{
	public Minion CreateAtPosition(Vector3 position)
	{
		var minion = new Minion(1, 0);
		Minion.Instantiate(minion);
		minion.SetPosition(position);
		WorkerDecorator workerDecorator = new WorkerDecorator(3, 5);
		IMinion minionInfo = minion.GetComponent<IMinion>();
		minionInfo = workerDecorator.Decorate(minion);

		return minion;
	}
}

public class WarriorFactory : IFactory<Minion>
{
	public Minion CreateAtPosition(Vector3 position)
	{
		var minion = new Minion(1, 0);
		minion.SetPosition(position);
		WarriorDecorator warriorDecorator = new WarriorDecorator(10, 15);
		IMinion minionInfo = minion.GetComponent<IMinion>();
		minionInfo = warriorDecorator.Decorate(minion);

		return minion;
	}
}

public class ScientistFactory : IFactory<Minion>
{
	public Minion CreateAtPosition(Vector3 position)
	{
		var minion = new Minion(1, 0);
		minion.SetPosition(position);
		ScientistDecorator scientistDecorator = new ScientistDecorator(2, 1);
		IMinion minionInfo = minion.GetComponent<IMinion>();
		minionInfo = scientistDecorator.Decorate(minion);

		return minion;
	}
}

