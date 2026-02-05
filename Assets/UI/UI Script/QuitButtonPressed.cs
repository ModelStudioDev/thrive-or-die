using UnityEngine;
using UnityEngine.UIElements;
using System;

public class QuitButtonPressed : MonoBehaviour
{

  private void OnEnable()
  {
    var root = GetComponent<UIDocument>().rootVisualElement;
    var quitButton = root.Q<Button>("Quit_Button");
    if (quitButton == null)
    {
      Debug.LogError("QuitButton not found in the UI Document.");
      return;
    }
    else
    {
      quitButton.clicked += OnQuitButtonClicked;
    }

  }

  private void OnQuitButtonClicked()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
  }
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
