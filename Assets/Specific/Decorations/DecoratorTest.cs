using NUnit.Framework.Constraints;
using UnityEngine;

public class DecoratorTest : MonoBehaviour
{
	IMinion workerMinion = new Minion(1, 0);
	IMinion workerFighterMinion = new Minion(1, 0);

	StateMachine stateMachine;
	private void Awake()
	{
		stateMachine = new StateMachine(workerFighterMinion);

		WorkerDecorator workerDecorator = new WorkerDecorator(3, 5);
		workerMinion = workerDecorator.Decorate(workerMinion);
		workerFighterMinion = workerDecorator.Decorate(workerFighterMinion);

		WarriorDecorator warriorDecorator = new WarriorDecorator(10, 15);
		workerFighterMinion = warriorDecorator.Decorate(workerFighterMinion);

		stateMachine.SetState(new WorkingState(workerFighterMinion));

		IMinion defaultMinion = new Minion(1, 0);
	}

	private void Update()
	{
		stateMachine.Update();
	}
}
