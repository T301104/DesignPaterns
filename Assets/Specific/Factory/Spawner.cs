using UnityEngine;

public class Spawner<T>
	
{
	private IFactory<T> factory;
	public Spawner(IFactory<T> factory)
	{
		this.factory = factory;
	}

	public T SpawnAtPosition(Vector3 position)
	{
		return factory.CreateAtPosition(position);
	}
}
