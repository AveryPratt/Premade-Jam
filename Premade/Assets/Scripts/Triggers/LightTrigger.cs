using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : Trigger
{
    public GameObject TransparentModel;

    protected override void Activate(Activator activator)
    {
        Debug.Log("activated");
        if (activator.Type == ActivatorType.Wolf)
        {
            TransparentModel.SetActive(true);
        }
        if (activator.Type == ActivatorType.Fox)
        {
            TransparentModel.SetActive(false);
        }
    }

    protected override void Deactivate(Activator activator)
    {

    }
}
