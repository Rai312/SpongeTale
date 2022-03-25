using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
public abstract class Bone : MonoBehaviour
{
    [SerializeField] private MovingTransition _movingTransition;
    [SerializeField] private DrawingTransition _drawingTransition;

    [SerializeField] protected float MoveDamperValue;
    [SerializeField] protected float MoveSpringValue;

    [SerializeField] protected float DrawDamperValue;
    [SerializeField] protected float DrawSpringValue;

    [SerializeField] protected float TargetJointMoveRotationZ;
    [SerializeField] protected float TargetJointDrawRotationZ;

    protected float TargetJointRotationW = 1f;
    protected ConfigurableJoint ConfigurableJoint;
    protected JointDrive JointSlerpDrive;

    private void OnEnable()
    {
        _movingTransition.Switched += SetJointsMovingSettings;
        _drawingTransition.Switched += SetJointsDrawingSettings;
    }

    private void OnDisable()
    {
        _movingTransition.Switched -= SetJointsMovingSettings;
        _drawingTransition.Switched -= SetJointsDrawingSettings;
    }

    private void Awake()
    {
        ConfigurableJoint = GetComponent<ConfigurableJoint>();
    }

    protected abstract void SetJointsMovingSettings();
    protected abstract void SetJointsDrawingSettings();
}



