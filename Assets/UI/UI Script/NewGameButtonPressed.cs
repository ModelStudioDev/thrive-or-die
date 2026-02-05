using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class NewGameButtonPressed : MonoBehaviour
{
  private string mainSceneName = "Test_MapGen";

  private void OnEnable()
  {
    var root = GetComponent<UIDocument>().rootVisualElement;
    var newGameButton = root.Q<Button>("Start_Button");

    if (newGameButton == null)
    {
      Debug.LogError("StartButton not found in the UI Document.");
      return;
    }
    else
    {
      newGameButton.clicked += OnNewGameButtonClicked;
    }

  }

  private void OnDisable()
  {
    var root = GetComponent<UIDocument>().rootVisualElement;
    var newGameButton = root.Q<Button>("Start_Button");

    if (newGameButton != null)
      newGameButton.clicked -= OnNewGameButtonClicked;
  }

  private void OnNewGameButtonClicked()
  {
    Debug.Log("Start Button Clicked. Loading main scene...");
    SceneManager.LoadSceneAsync("Test_MapGen");
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
