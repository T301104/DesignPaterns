using UnityEngine;

public interface IFactory<T>
{
    T CreateAtPosition(Vector3 position);
}
