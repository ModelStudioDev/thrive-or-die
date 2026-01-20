

using UnityEngine;

namespace ThriveOrDie.ResourceSystem
{
  public class ResourceManager : MonoBehaviour
  {
    #region Data
    /// <summary>The wood resource</summary>
    [SerializeField]
    private Resource wood = new Resource(ResourceType.Wood);
    /// <summary>The scrap resource</summary>
    [SerializeField]
    private Resource scrap = new Resource(ResourceType.Scrap);
    #endregion

  }
}
