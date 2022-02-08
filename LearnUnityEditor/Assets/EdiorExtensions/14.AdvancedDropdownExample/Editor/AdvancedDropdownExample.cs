using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

namespace EditorExtensions
{
    public class AdvancedDropdownExample :EditorWindow
    {

        [MenuItem("EditorExtensions/10.AdvancedDropdown/Open")]
        static void Open()
        {
            CreateInstance<AdvancedDropdownExample>().Show();
        }

        private void OnGUI()
        {
            var rect = GUILayoutUtility.GetRect(new GUIContent("Show"), EditorStyles.toolbarButton);
            if(GUI.Button(rect,new GUIContent("Show"), EditorStyles.toolbarButton))
            {
                var dropdown = new WeekdaysDropdown(new AdvancedDropdownState());
                dropdown.Show(rect);
            }
        }

        public class WeekdaysDropdown : AdvancedDropdown
        {
            public WeekdaysDropdown(AdvancedDropdownState state) : base(state)
            {

            }
            protected override AdvancedDropdownItem BuildRoot()
            {
                var root = new AdvancedDropdownItem("Weekdays");
                var firstHarf = new AdvancedDropdownItem("First half");
                var secondHarf = new AdvancedDropdownItem("Second half");
                var weekend = new AdvancedDropdownItem("Weekend");

                firstHarf.AddChild(new AdvancedDropdownItem("Monday"));
                firstHarf.AddChild(new AdvancedDropdownItem("Tuesday"));
                secondHarf.AddChild(new AdvancedDropdownItem("Wednesday"));
                secondHarf.AddChild(new AdvancedDropdownItem("Thursday"));
                weekend.AddChild(new AdvancedDropdownItem("Friday"));
                weekend.AddChild(new AdvancedDropdownItem("Saturday"));
                weekend.AddChild(new AdvancedDropdownItem("Sunday"));

                root.AddChild(firstHarf);
                root.AddChild(secondHarf);
                root.AddChild(weekend);

                return root;
            }
        }
    }
}