using UnityEngine;

public class InitializeMap : MonoBehaviour
{
    void Start()
    {
        if (AirportConfig.current == null)
        {
            Debug.LogError("No airport selected");
            return;
        }
        VtsMapMakeLocal mml = gameObject.AddComponent<VtsMapMakeLocal>();
        mml.latitude = AirportConfig.current.latitude;
        mml.longitude = AirportConfig.current.longitude;
        mml.altitude = AirportConfig.current.altitude;
        Destroy(this); // remove this component
    }
}
