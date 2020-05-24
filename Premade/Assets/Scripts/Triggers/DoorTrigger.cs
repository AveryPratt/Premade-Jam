using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Trigger
{
    public GameObject TransparentModel;
    public GameObject Collider;

    public override bool Activate(Activator activator)
    {
        if (activator != null)
        {
            if (activator.Type == ActivatorType.Fox)
            {
                Collider.layer = LayerMask.NameToLayer("MovePath");
                TransparentModel.SetActive(false);
                return true;
            }
        }
        return false;
    }

    public override bool Deactivate(Activator activator)
    {
        return false;
    }
}
