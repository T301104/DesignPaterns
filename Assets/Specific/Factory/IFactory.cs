using System.Collections.Generic;
using UnityEngine;

public interface IFactory<T>
{
    T CreateAtPosition(Vector3 position, GameObject minionModel, params MinionDecorator[] decorators);
}
