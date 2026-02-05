using UnityEngine;

public class MenuMusicScript : MonoBehaviour
{
  private static MenuMusicScript instance;
  private AudioSource audioSource;

  private void Awake()
  {
    // Singleton per evitare doppie musiche
    if (instance != null)
    {
      Destroy(gameObject);
      return;
    }

    instance = this;
    DontDestroyOnLoad(gameObject);

    audioSource = GetComponent<AudioSource>();
    audioSource.Play();
  }
}
