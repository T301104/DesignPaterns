//using UnityEngine;

//public class MinionController : MonoBehaviour
//{
//	IMinion workerMinion = new Minion(1, 0);
//	IMinion workerFighterMinion = new Minion(1, 0);

//	StateMachine stateMachine;
//	private void Awake()
//	{
//		stateMachine = new StateMachine(workerFighterMinion);
//	}

//	private void Update()
//	{
//		stateMachine.Update();
//	}

//	private void SetMineState()
//	{
//		stateMachine.SetState(new WorkingState());
//	}

//	private void SetFightState()
//	{
//		stateMachine.SetState(new WorkingState());
//	}
//}