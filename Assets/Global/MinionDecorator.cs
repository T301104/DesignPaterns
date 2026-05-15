using UnityEngine;

public abstract class MinionDecorator
{
    public int Hp { get; set; }
    public int Strength { get; set; } 
    
    public MinionDecorator(int hp, int str)
    {
        Hp = hp;
        Strength = str;
    }

    public abstract IMinion Decorate (IMinion minion);
}
