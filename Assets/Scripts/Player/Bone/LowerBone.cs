using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBone : Bone
{
    protected override void SetJointsMovingSettings()
    {
        ConfigurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
        ConfigurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
        ConfigurableJoint.angularZMotion = ConfigurableJointMotion.Locked;

        JointSlerpDrive = ConfigurableJoint.angularXDrive;
        JointSlerpDrive.positionDamper = MoveDamperValue;
        JointSlerpDrive.positionSpring = MoveSpringValue;

        ConfigurableJoint.slerpDrive = JointSlerpDrive;
        ConfigurableJoint.targetRotation = new Quaternion(Vector3.zero.x, Vector3.zero.y, TargetJointMoveRotationZ, TargetJointRotationW);
    }

    protected override void SetJointsDrawingSettings()
    {
        ConfigurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
        ConfigurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
        ConfigurableJoint.angularZMotion = ConfigurableJointMotion.Locked;

        JointSlerpDrive = ConfigurableJoint.angularXDrive;
        JointSlerpDrive.positionDamper = MoveDamperValue;
        JointSlerpDrive.positionSpring = MoveSpringValue;

        ConfigurableJoint.slerpDrive = JointSlerpDrive;
        ConfigurableJoint.targetRotation = new Quaternion(Vector3.zero.x, Vector3.zero.y, TargetJointDrawRotationZ, TargetJointRotationW);
    }
}
