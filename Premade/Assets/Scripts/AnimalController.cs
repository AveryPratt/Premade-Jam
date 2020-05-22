using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public GameObject Model;

    public bool IsMoving { get; private set; }

    private float MoveTimer = .3f;

    private void Update()
    {
        if (IsMoving)
        {
            MoveTimer -= Time.deltaTime;
            if (MoveTimer <= 0)
            {
                MoveTimer = .3f;
                IsMoving = false;
            }
        }
    }

    public void MoveNorth()
    {
        Model.transform.LookAt(transform.position + Vector3.forward);
        transform.Translate(Vector3.forward * 2);
        IsMoving = true;
    }

    public void MoveSouth()
    {
        Model.transform.LookAt(transform.position + Vector3.back);
        transform.Translate(Vector3.back * 2);
        IsMoving = true;
    }

    public void MoveWest()
    {
        Model.transform.LookAt(transform.position + Vector3.left);
        transform.Translate(Vector3.left * 2);
        IsMoving = true;
    }

    public void MoveEast()
    {
        Model.transform.LookAt(transform.position + Vector3.right);
        transform.Translate(Vector3.right * 2);
        IsMoving = true;
    }
}
