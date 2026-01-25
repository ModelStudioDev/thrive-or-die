
using System;
using ThriveOrDie.ResourceSystem;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace ThriveOrDie.Editors
{
  [CustomPropertyDrawer(typeof(ResourceAmount))]
  public class ResourceEditor : PropertyDrawer
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
      SerializedProperty amountProp = property.FindPropertyRelative("_amount");

      VisualElement root = GetVisualElement();
      if (root == null)
        return new Label("Missing ResourceProperty.uxml");

      Label name = root.Q<Label>("name");
      Label amount = root.Q<Label>("amount");
      IntegerField input = root.Q<IntegerField>("input");

      VisualElement defaultHolder = root.Q<VisualElement>("default");
      VisualElement editHolder = root.Q<VisualElement>("edit");

      Button setBtn = root.Q<Button>("setBtn");
      Button cancelBtn = root.Q<Button>("cancelBtn");
      Button confirmBtn = root.Q<Button>("confirmBtn");

      name.text = property.displayName;
      amount.text = amountProp.intValue.ToString();
      input.SetValueWithoutNotify(amountProp.intValue);



      Action<bool> toggleEditUI = (bool show) =>
      {
        defaultHolder.style.display = show ? DisplayStyle.None : DisplayStyle.Flex;
        editHolder.style.display = show ? DisplayStyle.Flex : DisplayStyle.None;
      };


      root.Q<Button>("setBtn").clicked += () => { toggleEditUI(true); input.Focus(); };
      root.Q<Button>("cancelBtn").clicked += () => { toggleEditUI(false); input.SetValueWithoutNotify(amountProp.intValue); };

      root.Q<Button>("confirmBtn").clicked += () =>
      {
        toggleEditUI(false);
        amountProp.intValue = input.value;
        input.SetValueWithoutNotify(amountProp.intValue);
        property.serializedObject.ApplyModifiedProperties();
      };

      root.TrackPropertyValue(amountProp, t =>
      {
        amount.text = amountProp.intValue.ToString();
        input.SetValueWithoutNotify(amountProp.intValue);
      });
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
        visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/ResourceSystem/ResourceAmount/Editor/ResourceProperty.uxml");
      }
      return visualTreeAsset != null ? visualTreeAsset.CloneTree() : null;
      #endregion
    }
    #endregion
  }
}
