using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Trigger : MonoBehaviour
{
    public bool ActivatedOnce { get; set; }
    public bool Activated { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        Activator[] activators = other.GetComponents<Activator>();
        if (activators != null && activators.Length > 0)
        {
            foreach (Activator activator in activators)
            {
                if (Activate(activator))
                {
                    Activated = true;
                    ActivatedOnce = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Activator activator = other.GetComponent<Activator>();
        if (activator != null)
        {
            if (Deactivate(activator))
            {
                Activated = false;
            }
        }
    }

    public abstract bool Activate(Activator activator = null);

    public abstract bool Deactivate(Activator activator = null);
}