
using ThriveOrDie.ResourceSystem;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace ThriveOrDie.Editors
{
  [CustomPropertyDrawer(typeof(Resource))]
  public class ResourceEditor : PropertyDrawer
  {

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {

      SerializedProperty resourceType = property.FindPropertyRelative("_resourceType");
      SerializedProperty amount = property.FindPropertyRelative("_amount");

      VisualElement root = new VisualElement();
      root.style.flexDirection = FlexDirection.Column;

      Label nameElm = new Label();
      nameElm.text = resourceType.enumDisplayNames[resourceType.intValue];
      nameElm.style.unityFontStyleAndWeight = FontStyle.Bold;
      root.Add(nameElm);

      VisualElement valuesHolder = new VisualElement();
      valuesHolder.style.paddingLeft = 10;
      valuesHolder.style.flexDirection = FlexDirection.Row;
      valuesHolder.style.justifyContent = Justify.SpaceBetween;

      root.Add(valuesHolder);

      Label amountElm = new Label();
      amountElm.text = amount.intValue.ToString();
      valuesHolder.Add(amountElm);


      Button setAmountButton = new Button();
      setAmountButton.text = "Set";
      valuesHolder.Add(setAmountButton);

      setAmountButton.clicked += () =>
      {
        Debug.Log("This is not implemented yet!");
      };

      root.TrackPropertyValue(amount, property =>
      {
        amountElm.text = property.intValue.ToString();
      });

      return root;
    }
  }
}
