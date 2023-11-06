<<<<<<< HEAD
using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
=======
using UnityEngine;
using UnityEngine.UI;
>>>>>>> 20a472256c66dc47b28ff1191b27c2f72f0cb032

namespace UnityEditor.UI
{
    [CustomPropertyDrawer(typeof(Navigation), true)]
    /// <summary>
    /// This is a PropertyDrawer for Navigation. It is implemented using the standard Unity PropertyDrawer framework.
    /// </summary>
    public class NavigationDrawer : PropertyDrawer
    {
<<<<<<< HEAD
        const string kNavigation = "Navigation";

        const string kModeProp = "m_Mode";
        const string kWrapAroundProp = "m_WrapAround";
        const string kSelectOnUpProp = "m_SelectOnUp";
        const string kSelectOnDownProp = "m_SelectOnDown";
        const string kSelectOnLeftProp = "m_SelectOnLeft";
        const string kSelectOnRightProp = "m_SelectOnRight";

        const string kHiddenClass = "unity-ui-navigation-hidden";

=======
>>>>>>> 20a472256c66dc47b28ff1191b27c2f72f0cb032
        private class Styles
        {
            readonly public GUIContent navigationContent;

            public Styles()
            {
<<<<<<< HEAD
                navigationContent = EditorGUIUtility.TrTextContent(kNavigation);
=======
                navigationContent = EditorGUIUtility.TrTextContent("Navigation");
>>>>>>> 20a472256c66dc47b28ff1191b27c2f72f0cb032
            }
        }

        private static Styles s_Styles = null;

        public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
        {
            if (s_Styles == null)
                s_Styles = new Styles();

            Rect drawRect = pos;
            drawRect.height = EditorGUIUtility.singleLineHeight;

<<<<<<< HEAD
            SerializedProperty navigation = prop.FindPropertyRelative(kModeProp);
            SerializedProperty wrapAround = prop.FindPropertyRelative(kWrapAroundProp);
=======
            SerializedProperty navigation = prop.FindPropertyRelative("m_Mode");
            SerializedProperty wrapAround = prop.FindPropertyRelative("m_WrapAround");
>>>>>>> 20a472256c66dc47b28ff1191b27c2f72f0cb032
            Navigation.Mode navMode = GetNavigationMode(navigation);

            EditorGUI.PropertyField(drawRect, navigation, s_Styles.navigationContent);

            ++EditorGUI.indentLevel;

            drawRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            switch (navMode)
            {
                case Navigation.Mode.Horizontal:
                case Navigation.Mode.Vertical:
                {
                    EditorGUI.PropertyField(drawRect, wrapAround);
                    drawRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                }
                break;
                case Navigation.Mode.Explicit:
                {
<<<<<<< HEAD
                    SerializedProperty selectOnUp = prop.FindPropertyRelative(kSelectOnUpProp);
                    SerializedProperty selectOnDown = prop.FindPropertyRelative(kSelectOnDownProp);
                    SerializedProperty selectOnLeft = prop.FindPropertyRelative(kSelectOnLeftProp);
                    SerializedProperty selectOnRight = prop.FindPropertyRelative(kSelectOnRightProp);
=======
                    SerializedProperty selectOnUp = prop.FindPropertyRelative("m_SelectOnUp");
                    SerializedProperty selectOnDown = prop.FindPropertyRelative("m_SelectOnDown");
                    SerializedProperty selectOnLeft = prop.FindPropertyRelative("m_SelectOnLeft");
                    SerializedProperty selectOnRight = prop.FindPropertyRelative("m_SelectOnRight");
>>>>>>> 20a472256c66dc47b28ff1191b27c2f72f0cb032

                    EditorGUI.PropertyField(drawRect, selectOnUp);
                    drawRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                    EditorGUI.PropertyField(drawRect, selectOnDown);
                    drawRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                    EditorGUI.PropertyField(drawRect, selectOnLeft);
                    drawRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                    EditorGUI.PropertyField(drawRect, selectOnRight);
                    drawRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                }
                break;
            }

            --EditorGUI.indentLevel;
        }

        static Navigation.Mode GetNavigationMode(SerializedProperty navigation)
        {
            return (Navigation.Mode)navigation.enumValueIndex;
        }

        public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
        {
<<<<<<< HEAD
            SerializedProperty navigation = prop.FindPropertyRelative(kModeProp);
=======
            SerializedProperty navigation = prop.FindPropertyRelative("m_Mode");
>>>>>>> 20a472256c66dc47b28ff1191b27c2f72f0cb032
            if (navigation == null)
                return EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            Navigation.Mode navMode = GetNavigationMode(navigation);

            switch (navMode)
            {
                case Navigation.Mode.None:
                    return EditorGUIUtility.singleLineHeight;
                case Navigation.Mode.Horizontal:
                case Navigation.Mode.Vertical:
                    return 2 * EditorGUIUtility.singleLineHeight + 2 * EditorGUIUtility.standardVerticalSpacing;
                case Navigation.Mode.Explicit:
                    return 5 * EditorGUIUtility.singleLineHeight + 5 * EditorGUIUtility.standardVerticalSpacing;
                default:
                    return EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            }
        }
<<<<<<< HEAD

        PropertyField PrepareField(VisualElement parent, string propertyPath, bool hideable = true, string label = null)
        {
            var field = new PropertyField(null, label) { bindingPath = propertyPath };
            if (hideable) field.AddToClassList(kHiddenClass);
            parent.Add(field);
            return field;
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement() { name = kNavigation };
            var indented = new VisualElement() { name = "Indent" };

            indented.AddToClassList("unity-ui-navigation-indent");

            var navigation = PrepareField(container, kModeProp, false, kNavigation);
            var wrapAround = PrepareField(indented, kWrapAroundProp);
            var selectOnUp = PrepareField(indented, kSelectOnUpProp);
            var selectOnDown = PrepareField(indented, kSelectOnDownProp);
            var selectOnLeft = PrepareField(indented, kSelectOnLeftProp);
            var selectOnRight = PrepareField(indented, kSelectOnRightProp);

            Action<Navigation.Mode> callback = (value) =>
            {
                wrapAround.EnableInClassList(kHiddenClass, value != Navigation.Mode.Vertical && value != Navigation.Mode.Horizontal);
                selectOnUp.EnableInClassList(kHiddenClass, value != Navigation.Mode.Explicit);
                selectOnDown.EnableInClassList(kHiddenClass, value != Navigation.Mode.Explicit);
                selectOnLeft.EnableInClassList(kHiddenClass, value != Navigation.Mode.Explicit);
                selectOnRight.EnableInClassList(kHiddenClass, value != Navigation.Mode.Explicit);
            };

            navigation.RegisterValueChangeCallback((e) => callback.Invoke((Navigation.Mode)e.changedProperty.enumValueIndex));
            callback.Invoke((Navigation.Mode)property.FindPropertyRelative(kModeProp).enumValueFlag);

            container.Add(indented);
            return container;
        }
=======
>>>>>>> 20a472256c66dc47b28ff1191b27c2f72f0cb032
    }
}
