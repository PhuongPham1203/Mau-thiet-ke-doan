using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Unit unit);

}
public class JumpCommand : Command
{
    public override void Execute(Unit unit)
    {
        unit.Jump();
    }
}

public class FireCommand : Command
{
    public override void Execute(Unit unit)
    {
        unit.Fire();
    }
}
public class SwapCommand : Command
{
    public override void Execute(Unit unit)
    {
        unit.SwapWeapon();
    }
}

