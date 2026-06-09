using UnityEngine;
using System;

[Flags] public enum MinionType
{
    Default = 0,
    Miner = 1,
    Warrior = 2,
    Farmer = 4
}

public interface IMinion : IStateRunner
{
    int Hp { get; set; }
    int Strength { get; set; }
	int hunger { get; set; }

	MinionType Miniontypes { get; set; }

    void Mine();
    void Fight();
    void Farm();
    void Eat();
    public void SetPosition(Vector3 position);

}

