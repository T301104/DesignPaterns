using System.Collections.Generic;
using UnityEngine;


public class MinionFactory : IFactory<Minion>
{
	public Minion CreateAtPosition(Vector3 position, GameObject minionModel, params MinionDecorator[] decorators)
	{
		var minion = new Minion(1, 0, minionModel);
		foreach (var decorator in decorators)
		{
			decorator.Decorate(minion);
		}

		return minion;
	}
}
