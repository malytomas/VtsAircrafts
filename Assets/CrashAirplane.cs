using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashAirplane : MonoBehaviour
{
    public GameObject explosionPrefab;

    int step;
    bool immune;

    void Start()
    {
        immune = true;
        step = 0;
    }

    void FixedUpdate()
    {
        if (step++ == 60 * 5)
            immune = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (immune)
            return;
        Debug.Log("Collision");
        foreach (var p in collision.contacts)
            Instantiate(explosionPrefab, p.point, Quaternion.FromToRotation(Vector3.up, p.normal));
        Destroy(gameObject);
    }
}
