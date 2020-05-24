using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MovementController
{
    public Directions[] Directions;
    private int Idx = 0;
    private float WaitTime = .7f;
    private float WaitTimer;

    private new void Update()
    {
        if (!IsMoving)
        {
            WaitTimer -= Time.deltaTime;

            if (WaitTimer <= 0)
            {
                if (Directions.Length > 0)
                {
                    switch (Directions[Idx])
                    {
                        case global::Directions.North:
                            TryMoveNorth();
                            break;
                        case global::Directions.South:
                            TryMoveSouth();
                            break;
                        case global::Directions.West:
                            TryMoveWest();
                            break;
                        case global::Directions.East:
                            TryMoveEast();
                            break;
                        default:
                            break;
                    }

                    Idx += 1;
                    if (Idx >= Directions.Length)
                    {
                        Idx = 0;
                    }
                }

                WaitTimer += WaitTime;
            }
        }

        base.Update();
    }
}