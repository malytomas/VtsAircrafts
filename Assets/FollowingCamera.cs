using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Vector3 targetOffset;
    public float cameraPitch;

    private GameObject target;

    Quaternion Rotation()
    {
        return target.transform.rotation * Quaternion.Euler(cameraPitch, 0, 0);
    }

    public void Initialize(GameObject target)
    {
        this.target = target;
        transform.rotation = Rotation();
        transform.position = target.transform.position + transform.rotation * targetOffset;
    }

    void FixedUpdate()
    {
        if (!target)
            return;
        Quaternion rot = Rotation();
        transform.position = Vector3.Lerp(transform.position, target.transform.position + rot * targetOffset, 0.1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 0.1f);
    }
}
