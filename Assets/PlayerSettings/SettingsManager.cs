using System.IO;
using System.Reflection;
using UnityEngine;


namespace ThriveOrDie.Settings
{
  /// <summary>Manages the player settings</summary>
  public static class SettingsManager
  {
    #region Data
    /// <summary>The default player settings</summary>
    private static PlayerSettings defaultSettings;
    /// <summary>The current player settings. Actual data</summary>
    private static PlayerSettings _currentSettings;
    /// <summary>The current player settings</summary>
    public static PlayerSettings currentSettings => GetCurrentSettings();
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
      defaultSettings = Resources.Load<PlayerSettings>("DefaultPlayerSettings");

      if (!isLoaded)
        _currentSettings = Object.Instantiate(defaultSettings);

      if (!File.Exists(settingsPath))
      {
        Save();
        isLoaded = true;
        return;
      }

      string settingsJson = File.ReadAllText(settingsPath);
      _currentSettings = Object.Instantiate(defaultSettings);
      JsonUtility.FromJsonOverwrite(settingsJson, _currentSettings);

      isLoaded = true;
      #endregion
    }

    /// <summary>Saves the current settings to disk</summary>
    private static void Save()
    {
      #region Save
      string settingsJson = JsonUtility.ToJson(_currentSettings, prettyPrint: true);
      File.WriteAllText(settingsPath, settingsJson);
      #endregion
    }

    /// <summary>Gets the current settings</summary>
    private static PlayerSettings GetCurrentSettings()
    {
      #region GetCurrentSettings
      if (!isLoaded) Load();
      return _currentSettings;
      #endregion
    }

    /// <summary>Sets a nnew value for the specified setting</summary>
    /// <typeparam name="Type">The value type</typeparam>
    /// <param name="name">The name of the setting</param>
    /// <param name="value">The value to set</param>
    public static void SetSettingValue<Type>(string name, Type value)
    {
      #region SetSetting

      FieldInfo[] fields = typeof(PlayerSettings).GetFields();
      foreach (FieldInfo field in fields)
      {
        if (field.Name != name) continue;
        if (field.FieldType != typeof(Type)) throw new System.Exception($"Unexpeccted type \"{typeof(Type).Name}\" for setting \"{name}\"");
        field.SetValue(_currentSettings, value);
        Save();
        return;
      }
      throw new System.Exception($"Unknown setting: {name}");
      #endregion
    }


    /// <summary>Resets the current settings to default values</summary>
    public static void ResetToDefaults()
    {
      #region ResetToDefaults
      JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(defaultSettings), _currentSettings);
      Save();
      #endregion
    }
    #endregion
  }
}
