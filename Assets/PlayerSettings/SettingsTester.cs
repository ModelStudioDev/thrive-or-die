using UnityEngine;


namespace ThriveOrDie.Settings
{
  public class SettingsTester : MonoBehaviour
  {
    void Start()
    {
      PlayerSettings settings = SettingsManager.currentSettings;
      Debug.Log("Settings loaded!");
      Debug.Log($"Camera sennsitivity is: {settings.cameraSensibility}");
      SettingsManager.SetSettingValue("cameraSensibility", 10f);
      Debug.Log($"Camera sennsitivity is: {settings.cameraSensibility}");
    }
  }

}
