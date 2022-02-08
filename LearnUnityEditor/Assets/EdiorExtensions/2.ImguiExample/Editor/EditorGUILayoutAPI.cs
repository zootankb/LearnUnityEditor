using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace EditorExtensions
{
    public class EditorGUILayoutAPI
    {
        private BuildTargetGroup mBuildTargetGroup;
        private AnimBool mAnimBool = new AnimBool();
        private bool mFoldOutGroup = false;
        private bool mGroupValue = false;
        private bool mToggleValue1 = false;
        private bool mToggleValue2 = false;
        public void Draw()
        {
            mAnimBool.target = EditorGUILayout.ToggleLeft("Toggle Left", mAnimBool.target);

            mFoldOutGroup = EditorGUILayout.BeginFoldoutHeaderGroup(mFoldOutGroup, "FoldoutHeader");
            {
                if (mFoldOutGroup)
                {
                    EditorGUILayout.BeginFadeGroup(mAnimBool.faded);
                    {
                        if (mAnimBool.target)
                        {
                            mBuildTargetGroup = EditorGUILayout.BeginBuildTargetSelectionGrouping();
                            {

                            }
                            EditorGUILayout.EndBuildTargetSelectionGrouping();
                        }
                    }
                    EditorGUILayout.EndFadeGroup();
                }
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            mGroupValue = EditorGUILayout.BeginToggleGroup("组内是否能交互", mGroupValue);
            mToggleValue1 = EditorGUILayout.Toggle(mToggleValue1);
            mToggleValue2 = EditorGUILayout.Toggle(mToggleValue2);
            EditorGUILayout.EndToggleGroup();

        }
    }

}