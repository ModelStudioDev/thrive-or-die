using UnityEngine;

public static class VectorExtensions
{
  public static void Deconstruct(this Vector2Int vector, out int x, out int y)
  {
    #region Deconstruct Vector2Int
    x = vector.x;
    y = vector.y;
    #endregion
  }

  public static void Deconstruct(this Vector3Int v, out int x, out int y, out int z)
  {
    #region Deconstruct Vector3Int
    x = v.x;
    y = v.y;
    z = v.z;
    #endregion
  }
}
