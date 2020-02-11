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
using System.Collections;

/// <summary>
/// Demonstrates how to add custom commands on the HMT
/// </summary>
public class AddCommands : Example
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

        // Add custom commands 
        m_wearHF.AddVoiceCommand("Command 1", LogCommandCallback);
        m_wearHF.AddVoiceCommand("Command 2", LogCommandCallback);
        m_wearHF.AddVoiceCommand("Command 3", LogCommandCallback);

        // Clean up when we're finished.
        SceneManager.sceneUnloaded += SceneUnloaded;
    }

    /// <summary>
    /// Called when our custom commands are spoken.
    /// </summary>
    /// <param name="voiceCommand">The voice command that was recognized.</param>
    private void LogCommandCallback(string voiceCommand)
    {
        Debug.Log("Command Recognized: " + voiceCommand);
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