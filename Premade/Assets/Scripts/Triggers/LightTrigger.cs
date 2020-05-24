using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : Trigger
{
    public GameObject TransparentModel;
    public bool StartLit;
    
    public bool IsLit
    {
        get
        {
            return TransparentModel.activeInHierarchy;
        }
    }

    private void OnEnable()
    {
        if (StartLit)
        {
            TransparentModel.SetActive(true);
        }
    }

    public void GoDark()
    {
        TransparentModel.SetActive(false);
        Activated = false;
    }

    public override bool Activate(Activator activator)
    {
        if (activator != null)
        {
            if (activator.Type == ActivatorType.Wolf || activator.Type == ActivatorType.Fox)
            {
                TransparentModel.SetActive(true);
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
