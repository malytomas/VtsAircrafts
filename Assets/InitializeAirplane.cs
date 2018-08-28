using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;

public class InitializeAirplane : MonoBehaviour
{
    public GameObject map;

    private int step;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        transform.Rotate(
            AirportConfig.current.pitch,
            AirportConfig.current.yaw,
            AirportConfig.current.roll
            );
        Camera.main.GetComponent<FollowingCamera>().Initialize(gameObject);
        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour c in comps)
            c.enabled = false;
        enabled = true;
    }

    void FixedUpdate()
    {
        if (step++ < 100)
            return;
        if (map.GetComponent<VtsMap>().map.GetMapRenderComplete())
        {
            MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour c in comps)
                c.enabled = true;
            rb.isKinematic = false;
            Destroy(this); // destroy this component
        }
    }
}
