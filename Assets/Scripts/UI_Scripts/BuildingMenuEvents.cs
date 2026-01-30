using UnityEngine;
using UnityEngine.UIElements;

public class BuildingMenuEvents : MonoBehaviour
{
  /// <summary>
  /// The UI document of the building menu main button
  /// </summary>
  private UIDocument _document;
  [SerializeField] UIDocument buildingMenu_Document;
  /// <summary>
  /// The button
  /// </summary>
  private Button button;
  private AudioSource buttonSound;

  private void Awake()
  {
    _document = GetComponent<UIDocument>();
    buttonSound = GetComponent<AudioSource>();
    button = _document.rootVisualElement.Q("BuildingMenuButton") as Button;
    button.RegisterCallback<ClickEvent>(OnBuildMenuClick);
    buildingMenu_Document.enabled = false;
  }

  private void OnDisable()
  {
    button.UnregisterCallback<ClickEvent>(OnBuildMenuClick);
  }

  private void OnBuildMenuClick(ClickEvent evt) {
    Debug.Log("Building Menu clicked");
    buildingMenu_Document.enabled = true;
    buttonSound.Play();
  }

}
