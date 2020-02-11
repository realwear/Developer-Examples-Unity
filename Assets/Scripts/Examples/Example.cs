using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Abstract class containing common code that each example requires to function, but isn't
/// actually part of what the example is trying to show.
/// </summary>
public abstract class Example : MonoBehaviour
{
    /// <summary>
    /// See Unity docs.
    /// </summary>
    void Update()
    {
        // Handle "Navigate Back" commands from WearHF.
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}