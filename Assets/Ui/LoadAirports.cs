using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[Serializable]
public class AirportConfig
{
    public string name;
    public float latitude;
    public float longitude;
    public float altitude;
    public float pitch;
    public float yaw;
    public float roll;

    public static AirportConfig current;
}

[Serializable]
internal class AirportsCollection
{
    public List<AirportConfig> airports;
}

public class LoadAirports : MonoBehaviour
{
    public TextAsset airportsConfig;
    public GameObject button;
    public string scene;

    void Start()
    {
        AirportsCollection cfg = JsonUtility.FromJson<AirportsCollection>(airportsConfig.text);
        float offset = 0;
        foreach (AirportConfig ac in cfg.airports)
        {
            GameObject bo = Instantiate(button, button.transform.position, button.transform.rotation);
            bo.transform.SetParent(transform, false);
            bo.transform.Translate(0, -offset, 0);
            offset += 60;
            Text txt = bo.GetComponentInChildren<Text>();
            txt.text = ac.name;
            bo.GetComponent<Button>().onClick.AddListener(delegate { OnClick(ac); });
        }
    }

    public void OnClick(AirportConfig airport)
    {
        AirportConfig.current = airport;
        SceneManager.LoadScene(scene);
    }
}
