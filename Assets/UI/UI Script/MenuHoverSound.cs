using UnityEngine;
using UnityEngine.UIElements;

public class MenuHoverSound : MonoBehaviour
{
  public AudioSource audioSource;
  public AudioClip hoverClip;

  private void OnEnable()
  {
    var root = GetComponent<UIDocument>().rootVisualElement;

    var buttons = root.Query<Button>(className: "button").ToList();

    foreach (var button in buttons)
    {
      button.RegisterCallback<PointerEnterEvent>(OnHover);
    }

  }

  private void OnHover(PointerEnterEvent evt)
  {
    if (hoverClip == null || audioSource == null)
    {
      return;
    }
    audioSource.PlayOneShot(hoverClip);
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
