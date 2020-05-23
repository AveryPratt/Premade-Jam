using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public GameObject Model;

    public bool IsMoving { get; private set; }
    public AnimalType AnimalType;
    public float JumpTime = .3f;

    private float MoveTimer;
    private float FaceAngle;
    private float MoveAngle;
    private Vector3 MovePoint;
    private Vector3 StartPoint;

    private void Start()
    {
        MoveTimer = JumpTime;
    }

    private void Update()
    {
        if (IsMoving)
        {
            MoveTimer -= Time.deltaTime;
            transform.position = Vector3.Lerp(MovePoint, StartPoint, MoveTimer / JumpTime);
            Model.transform.position = transform.position + Vector3.up * Mathf.Sin(MoveTimer * Mathf.PI / JumpTime);
            
            if (MoveAngle - FaceAngle > 180)
            {
                MoveAngle -= 360;
            }
            else if (FaceAngle - MoveAngle > 180)
            {
                FaceAngle -= 360;
            }
            
            Model.transform.rotation = Quaternion.Euler(30 * (1 - MoveTimer / JumpTime) - 15, Mathf.Lerp(MoveAngle, FaceAngle, MoveTimer / JumpTime), Model.transform.rotation.z);

            if (MoveTimer <= 0)
            {
                transform.position = MovePoint;
                Model.transform.rotation = Quaternion.Euler(0, MoveAngle, Model.transform.rotation.z);
                FaceAngle = MoveAngle;
                MoveTimer = JumpTime;
                IsMoving = false;
            }
        }
    }

    public void TryMoveNorth()
    {
        StartPoint = transform.position;
        MovePoint = transform.position + Vector3.forward * 2;
        MoveAngle = 0;

        VerifyMovement();
    }

    public void TryMoveSouth()
    {
        StartPoint = transform.position;
        MovePoint = transform.position + Vector3.back * 2;
        MoveAngle = 180;

        VerifyMovement();
    }

    public void TryMoveWest()
    {
        StartPoint = transform.position;
        MovePoint = transform.position + Vector3.left * 2;
        MoveAngle = 270;

        VerifyMovement();
    }

    public void TryMoveEast()
    {
        StartPoint = transform.position;
        MovePoint = transform.position + Vector3.right * 2;
        MoveAngle = 90;

        VerifyMovement();
    }

    private void VerifyMovement()
    {
        Ray ray = new Ray(StartPoint + Vector3.up * .5f, MovePoint - StartPoint);
        if (Physics.Raycast(ray, 2))
        {
            MovePoint = StartPoint;
        }
        IsMoving = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(StartPoint + Vector3.up * .5f, MovePoint + Vector3.up * .5f);
    }
}

public enum AnimalType
{
    Fox,
    Wolf
}