using UnityEngine;

public class PointFollowCamera : MonoBehaviour
{
    [SerializeField] private MoverZ _movingZ;

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _movingZ.transform.position.z);
    }
}

