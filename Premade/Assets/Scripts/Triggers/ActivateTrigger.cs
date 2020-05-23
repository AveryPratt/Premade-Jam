using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : Trigger
{
    public GameObject Target;

    public override bool Activate(Activator activator = null)
    {
        if (Target != null)
        {
            Target.SetActive(true);
            return true;
        }
        return false;
    }

    public override bool Deactivate(Activator activator = null)
    {
        return false;
    }
}
