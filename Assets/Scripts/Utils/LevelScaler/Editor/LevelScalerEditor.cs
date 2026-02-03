
using System;
using ThriveOrDie.Utils;
using UnityEditor;
using UnityEngine.UIElements;



namespace ThriveOrDie.Editors
{
  [CustomPropertyDrawer(typeof(LevelScaler))]
  public class LevelScalarEditor : PropertyDrawer
  {
    #region Data
    /// <summary>The underlying visual tree asset</summary>
    private static VisualTreeAsset visualTreeAsset;
    #endregion

    #region Unity
    /// <summary>Called by Unity</summary>
    /// <param name="property">The Serialized prooperty</param>
    /// <returns>The created VisualElement</returns>
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
      #region CreatePropertyGUI
      return RenderResourceAmount(property);
      #endregion
    }
    #endregion

    #region Rendering
    /// <summary>Renders the resource amount propperty</summary>
    /// <param name="property">The ResourceAmount serialized property</param>
    /// <returns>The created and configured VisualElement</returns>
    private VisualElement RenderResourceAmount(SerializedProperty property)
    {
      #region RenderResourceAmount
      // SerializedProperty baseValueProp = property.FindPropertyRelative("_baseValue");


      VisualElement root = GetVisualElement();
      if (root == null)
        return new Label("Missing LevelScalarProperty.uxml");

      Label name = root.Q<Label>("name");
      // Label amount = root.Q<Label>("amount");
      // amount.text = baseValueProp.floatValue.ToString();


      name.text = property.displayName;
      // input.SetValueWithoutNotify(amountProp.intValue);



      return root;
      #endregion
    }
    #endregion

    #region Methods
    /// <summary>Creates the root visual element</summary>
    /// <returns>The created root visual element</returns>
    private VisualElement GetVisualElement()
    {
      #region GetVisualElement
      if (visualTreeAsset == null)
      {
        visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/Utils/LevelScaler/Editor/LevelScalarProperty.uxml");
      }
      return visualTreeAsset != null ? visualTreeAsset.CloneTree() : null;
      #endregion
    }
    #endregion
  }
}
