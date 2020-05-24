using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : Trigger
{
    public GameObject Target;
    public Transform SpawnPoint;

    public override bool Activate(Activator activator = null)
    {
        if (Target != null)
        {
            Target.SetActive(true);
            Target.transform.position = SpawnPoint.transform.position;

            DeathController deathController = Target.GetComponent<DeathController>();
            MovementController movementController = Target.GetComponent<MovementController>();
            if (deathController != null)
            {
                deathController.IsDead = false;
            }
            if (movementController != null)
            {
                movementController.TryMoveNone();
                movementController.CanMove = true;
            }

            return true;
        }
        return false;
    }

    public override bool Deactivate(Activator activator = null)
    {
        return false;
    }
}
