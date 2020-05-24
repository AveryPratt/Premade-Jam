using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MovementController
{
    public Directions[] Directions;
    public bool FixedPath;

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
                    bool moved = false;

                    switch (Directions[Idx])
                    {
                        case global::Directions.None:
                            moved = TryMoveNone();
                            break;
                        case global::Directions.North:
                            moved = TryMoveNorth();
                            break;
                        case global::Directions.South:
                            moved = TryMoveSouth();
                            break;
                        case global::Directions.West:
                            moved = TryMoveWest();
                            break;
                        case global::Directions.East:
                            moved = TryMoveEast();
                            break;
                        default:
                            break;
                    }

                    if (moved || !FixedPath)
                    {
                        Idx += 1;
                        if (Idx >= Directions.Length)
                        {
                            Idx = 0;
                        }
                    }
                }
                else
                {
                    TryMoveNone();
                }

                WaitTimer += WaitTime;
            }
        }

        base.Update();
    }
}