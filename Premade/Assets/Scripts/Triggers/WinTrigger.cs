using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : Trigger
{
    public override bool Activate(Activator activator = null)
    {
        if (activator != null)
        {
            if (activator.Type == ActivatorType.Wolf)
            {
                GameManager.Instance.HUD.Win();
                return true;
            }
        }
        return false;
    }

    public override bool Deactivate(Activator activator = null)
    {
        return false;
    }
}
