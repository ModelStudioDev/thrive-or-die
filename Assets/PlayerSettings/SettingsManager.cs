using System.IO;
using UnityEngine;

/// <summary>Manages the player settings</summary>
public static class SettingsManager
{
  #region Data
  /// <summary>The default player settings</summary>
  [SerializeField]
  private static PlayerSettings defaultSettings;
  /// <summary>The current player settings</summary>
  public static PlayerSettings currentSettings { get; private set; }
  /// <summary>Whether the settings are loaded</summary>
  public static bool isLoaded { get; private set; } = false;
  /// <summary>The settings file path</summary>
  private static string settingsPath => Path.Combine(Application.persistentDataPath, "PlayerSettings.json");
  #endregion

  #region Methods
  /// <summary>Loads the player settings</summary>
  public static void Load()
  {
    #region Load
    if (!File.Exists(settingsPath))
    {
      currentSettings = Object.Instantiate(defaultSettings);
      Save();
      isLoaded = true;
      return;
    }

    string settingsJson = File.ReadAllText(settingsPath);
    currentSettings = Object.Instantiate(defaultSettings);
    JsonUtility.FromJsonOverwrite(settingsJson, currentSettings);

    isLoaded = true;
    #endregion
  }

  /// <summary>Saves the current settings to disk</summary>
  private static void Save()
  {
    #region Save
    string settingsJson = JsonUtility.ToJson(currentSettings, prettyPrint: true);
    File.WriteAllText(settingsPath, settingsJson);
    #endregion
  }

  #endregion
}
