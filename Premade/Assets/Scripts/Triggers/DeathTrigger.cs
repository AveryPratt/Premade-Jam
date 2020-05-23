using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : Trigger
{
    public MovementController MovementController;
    public DeathController DeathController;

    public override bool Activate(Activator activator)
    {
        if (activator == null || activator.Type == ActivatorType.Kill)
        {
            MovementController.CanMove = false;
            DeathController.IsDead = true;
            return true;
        }
        return false;
    }

    public override bool Deactivate(Activator activator)
    {
        return false;
    }
}
