///////////////////////////////////////////////////////////////////////////////
//
// RealWear Development Software, Source Code and Object Code
// (c) RealWear, Inc. All rights reserved.
//
// Contact info@realwear.com for further information about the use of this
// code.
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;
using WearHFPlugin;

/// <summary>
/// Demonstrates how to use the RealWear TTS engine in Unity
/// </summary>
public class TextToSpeech : Example
{
    /// <summary>
    /// The WearHF object
    /// </summary>
    private WearHF m_wearHF;

    /// <summary>
    /// See Unity docs
    /// </summary>
    void Start()
    {
        // Initialize the wearHF object
        // NOTE: The plugin registers itself to the WearHF system in the
        // GameObject’s Awake function, so any calls to the plugin need to occur
        // after that. The start function is a good choice.
        m_wearHF = GameObject.Find("WearHF Manager").GetComponent<WearHF>();

        // Add a TTS command
        m_wearHF.AddTTSCommand(1, "Welcome to the HMT-1 from RealWear. " +
            "This is the Text to Speech Engine Example", TtsCallback);

        // Clean up when we're finished.
        SceneManager.sceneUnloaded += SceneUnloaded;
    }

    /// <summary>
    /// Called when TTS has finished playing.
    /// </summary>
    /// <param name="id">Unique identifier associated with the TTS command.</param>
    public void TtsCallback(int id)
    {
        Debug.Log("TTS Event completed: " + id);
    }

    /// <summary>
    /// Called when the scene is unloaded.
    /// Used to clean up WearHF.
    /// </summary>
    /// <param name="scene">The unloaded scene.</param>
    private void SceneUnloaded(Scene scene)
    {
        m_wearHF.ClearCommands();
    }
}
