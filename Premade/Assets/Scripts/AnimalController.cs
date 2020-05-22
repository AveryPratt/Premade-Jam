using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public GameObject Model;

    public bool IsMoving { get; private set; }
    public AnimalType AnimalType;

    private float MoveTimer = .3f;
    private float FaceAngle;
    private float MoveAngle;
    private Vector3 MovePoint;
    private Vector3 StartPoint;

    private void Update()
    {
        if (IsMoving)
        {
            MoveTimer -= Time.deltaTime;
            transform.position = Vector3.Lerp(MovePoint, StartPoint, MoveTimer / .3f);
            Model.transform.position = transform.position + Vector3.up * Mathf.Sin(MoveTimer * Mathf.PI / .3f);

            if (MoveAngle - FaceAngle > 180)
            {
                MoveAngle -= 360;
            }
            else if (FaceAngle - MoveAngle > 180)
            {
                FaceAngle -= 360;
            }
            
            Model.transform.rotation = Quaternion.Euler(30 * (1 - MoveTimer / .3f) - 15, Mathf.Lerp(MoveAngle, FaceAngle, MoveTimer / .3f), Model.transform.rotation.z);

            if (MoveTimer <= 0)
            {
                transform.position = MovePoint;
                Model.transform.rotation = Quaternion.Euler(0, MoveAngle, Model.transform.rotation.z);
                FaceAngle = MoveAngle;
                MoveTimer = .3f;
                IsMoving = false;
            }
        }
    }

    public void MoveNorth()
    {
        StartPoint = transform.position;
        MovePoint = transform.position + Vector3.forward * 2;
        MoveAngle = 0;
        IsMoving = true;
    }

    public void MoveSouth()
    {
        StartPoint = transform.position;
        MovePoint = transform.position + Vector3.back * 2;
        MoveAngle = 180;
        IsMoving = true;
    }

    public void MoveWest()
    {
        StartPoint = transform.position;
        MovePoint = transform.position + Vector3.left * 2;
        MoveAngle = 270;
        IsMoving = true;
    }

    public void MoveEast()
    {
        StartPoint = transform.position;
        MovePoint = transform.position + Vector3.right * 2;
        MoveAngle = 90;
        IsMoving = true;
    }
}

public enum AnimalType
{
    Fox,
    Wolf
}