using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject Model;

    public bool CanMove { get; set; } = true;
    public bool IsMoving { get; protected set; }
    public float JumpTime = .3f;
    public string[] MoveLayerNames = new string[] { "MovePath" };
    public string[] BlockLayerNames = new string[] { "BlockPath", "Squishy", "MovePathTransparent" };

    protected float MoveTimer;
    protected float FaceAngle;
    protected float MoveAngle;
    protected Vector3 MovePoint;
    protected Vector3 StartPoint;

    private bool Died = false;

    private void Start()
    {
        MoveTimer = JumpTime;
    }

    protected void Update()
    {
        if (!CanMove)
        {
            if (!Died)
            {
                transform.position = MovePoint;
                Model.transform.position = MovePoint;
                Model.transform.rotation = Quaternion.Euler(0, MoveAngle, Model.transform.rotation.z);
                FaceAngle = MoveAngle;
                MoveTimer = JumpTime;
                IsMoving = false;
                Died = true;
            }
        }
        else if (IsMoving)
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
                MoveTimer += JumpTime;
                IsMoving = false;
            }
        }
    }

    public void TryMoveNorth()
    {
        StartPoint = transform.position;
        MovePoint = transform.position + Vector3.forward * 2;
        MoveAngle = 0;

        VerifyMovement(MoveLayerNames, BlockLayerNames);
    }

    public void TryMoveSouth()
    {
        StartPoint = transform.position;
        MovePoint = transform.position + Vector3.back * 2;
        MoveAngle = 180;

        VerifyMovement(MoveLayerNames, BlockLayerNames);
    }

    public void TryMoveWest()
    {
        StartPoint = transform.position;
        MovePoint = transform.position + Vector3.left * 2;
        MoveAngle = 270;

        VerifyMovement(MoveLayerNames, BlockLayerNames);
    }

    public void TryMoveEast()
    {
        StartPoint = transform.position;
        MovePoint = transform.position + Vector3.right * 2;
        MoveAngle = 90;

        VerifyMovement(MoveLayerNames, BlockLayerNames);
    }

    private void VerifyMovement(string[] moveLayerNames, string[] blockLayerNames)
    {
        Ray ray = new Ray(StartPoint + Vector3.up * .5f, MovePoint - StartPoint);
        bool onPath = Physics.Raycast(ray, 2);
        if (!CanMove
            || !Physics.Raycast(ray, 2, LayerMask.GetMask(moveLayerNames))
            || Physics.Raycast(ray, 2, LayerMask.GetMask(blockLayerNames)))
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