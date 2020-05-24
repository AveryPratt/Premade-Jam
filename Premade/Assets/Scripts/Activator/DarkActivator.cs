using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkActivator : Activator
{
    public Trigger Trigger;

    private void Start()
    {
        Type = ActivatorType.Dark;
    }

    private void Update()
    {
        bool inLight = false;
        foreach (LightTrigger light in GameManager.Instance.Lights)
        {
            if (light.IsLit && Vector3.SqrMagnitude(light.transform.position - transform.position) < 25)
            {
                inLight = true;
                break;
            }
        }
        if (!inLight)
        {
            Trigger.Activate();
        }
    }
}
