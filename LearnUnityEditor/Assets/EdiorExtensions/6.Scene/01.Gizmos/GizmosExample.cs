using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorExtensions
{
    public class GizmosExample : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            var color = Gizmos.color;
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(Vector3.zero, Vector3.one);
            Gizmos.DrawWireCube(Vector3.one, Vector3.one);
            Gizmos.DrawGUITexture(new Rect(Vector2.zero, Vector2.one * 5), Texture2D.whiteTexture);
            Gizmos.color = color;
        }

        private void OnDrawGizmosSelected()
        {
            var color = Gizmos.color;
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, Vector3.one);
            Gizmos.color = color;
        }

#if UNITY_EDITOR
        /// <summary>
        /// 用此标记方法，不用在普通函数里写了，自动在UnityEditor.GizmoType.Active | UnityEditor.GizmoType.Selected的时候执行
        /// </summary>
        /// <param name="target"></param>
        /// <param name="gizmoType"></param>
        [UnityEditor.DrawGizmo(UnityEditor.GizmoType.Active | UnityEditor.GizmoType.Selected)]
        private static void MuCustomOnDrawGizmos(GizmosExample target, UnityEditor.GizmoType gizmoType)
        {
            var color = Gizmos.color;
            Gizmos.color = Color.green;
            Gizmos.DrawCube(target.transform.position + Vector3.one, Vector3.one); 
            Gizmos.color = color;
        }
#endif
    }
}