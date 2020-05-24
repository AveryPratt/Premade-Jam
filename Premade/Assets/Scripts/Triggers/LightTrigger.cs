using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : Trigger
{
    public GameObject TransparentModel;
    
    public bool IsLit
    {
        get
        {
            return TransparentModel.activeInHierarchy;
        }
    }

    public override bool Activate(Activator activator)
    {
        if (activator != null)
        {
            if (activator.Type == ActivatorType.Wolf)
            {
                TransparentModel.SetActive(true);
                return true;
            }
            if (activator.Type == ActivatorType.Fox)
            {
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
