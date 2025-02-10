using UnityEngine;

public class Troll : Monster
{
    protected override void Init()
    {
        base.Init();

        hp = 3f;
        speed = 1f;
    }
}