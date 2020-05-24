using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActivator : Activator
{
    public Trigger Trigger;

    private void Start()
    {
        Type = ActivatorType.Light;
    }

    private void Update()
    {
        foreach (LightTrigger light in GameManager.Instance.Lights)
        {
            if (light.IsLit && Vector3.SqrMagnitude(light.transform.position - transform.position) < 16)
            {
                Trigger.Activate();
                break;
            }
        }
    }
}
