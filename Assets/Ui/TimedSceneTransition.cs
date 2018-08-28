using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedSceneTransition : MonoBehaviour
{
    public int steps = 90;
    public string scene;

    private void FixedUpdate()
    {
        if (--steps <= 0)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
