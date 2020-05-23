using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Activator activator = other.GetComponent<Activator>();
        if (activator != null)
        {
            Activate(activator);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Activator activator = other.GetComponent<Activator>();
        if (activator != null)
        {
            Activate(activator);
        }
    }

    protected abstract void Activate(Activator activator);

    protected abstract void Deactivate(Activator activator);
}