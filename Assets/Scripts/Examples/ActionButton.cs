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
/// Demonstrates how to disable the Action Button on the HMT
/// </summary>
public class ActionButton : Example
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

        // Disable the Action Button for this scene
        m_wearHF.EnableActionButton = false;

        // Clean up when we're finished.
        SceneManager.sceneUnloaded += SceneUnloaded;
    }

    /// <summary>
    /// Called when the scene is unloaded.
    /// Used to clean up WearHF.
    /// </summary>
    /// <param name="scene">The unloaded scene.</param>
    private void SceneUnloaded(Scene scene)
    {
        // Clean up WearHF.
        m_wearHF.EnableActionButton = true;
        m_wearHF.ClearCommands();
    }
}