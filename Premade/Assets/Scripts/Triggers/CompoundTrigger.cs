using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoundTrigger : MonoBehaviour
{
    public Trigger[] Triggers;
    public Trigger AllActiveTrigger;
    public Trigger AllActiveOnceTrigger;

    private bool AllActiveTriggered;
    private bool AllActiveOnceTriggered;

    private void Update()
    {
        bool allActive = true;
        bool allActiveOnce = true;

        foreach (Trigger trigger in Triggers)
        {
            if (!trigger.Activated)
            {
                allActive = false;
            }
            if (!trigger.ActivatedOnce)
            {
                allActiveOnce = false;
            }
        }

        if (AllActiveTrigger != null)
        {
            if (allActive)
            {
                if (!AllActiveTriggered)
                {
                    AllActiveTrigger.Activate(null);
                    AllActiveTriggered = true;
                }
            }
            else
            {
                AllActiveTriggered = false;
            }
        }

        if (AllActiveOnceTrigger != null && allActiveOnce && !AllActiveOnceTriggered)
        {
            AllActiveOnceTrigger.Activate(null);
            AllActiveOnceTriggered = true;
        }
    }
}
