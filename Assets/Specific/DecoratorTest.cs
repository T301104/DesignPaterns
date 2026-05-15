using NUnit.Framework.Constraints;
using UnityEngine;

public class DecoratorTest : MonoBehaviour
{
	private void Awake()
	{
		IMinion workerMinion = new Minion(1, 0);
		IMinion workerFighterMinion = new Minion(1, 0);

		WorkerDecorator workerDecorator = new WorkerDecorator(3, 5);
		workerMinion = workerDecorator.Decorate(workerMinion);
		workerFighterMinion = workerDecorator.Decorate(workerFighterMinion);

		WarriorDecorator warriorDecorator = new WarriorDecorator(10, 15);
		workerFighterMinion = warriorDecorator.Decorate(workerFighterMinion);

		workerMinion.Work();
		workerFighterMinion.Work();
		
		IMinion defaultMinion = new Minion(1, 0);
		defaultMinion.Work();	
	}
}
