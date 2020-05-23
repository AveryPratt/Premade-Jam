using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Trigger
{
    public override bool Activate(Activator activator)
    {
        return false;
    }

    public override bool Deactivate(Activator activator)
    {
        return false;
    }
}
