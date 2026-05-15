using UnityEngine;
using UnityEngine.UI;

public class SpawnActivator : MonoBehaviour
{
	private void Awake()
	{
	}

	public void SpawnWorker()
	{
		var minionSpawner = new Spawner<Minion>(new WorkerFactory());
		minionSpawner.SpawnAtPosition(Vector3.one);
	}
	public void SpawnWarrior()
	{
		var minionSpawner = new Spawner<Minion>(new WarriorFactory());
		minionSpawner.SpawnAtPosition(Vector3.one);
	}
	public void SpawnScientist()
	{
		var minionSpawner = new Spawner<Minion>(new ScientistFactory());
		minionSpawner.SpawnAtPosition(Vector3.one);
	}
}
