using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorExtensions
{
    /// <summary>
    /// 脚本所挂物体的右侧圆形问号点击后引导的地址
    /// </summary>
    [HelpURL("https://unity.cn")]
    public class AttributeExample : MonoBehaviour
    {

        public int Age;

        [HideInInspector]
        public int Age1;

        [Header("年龄")]
        [SerializeField]
        private int Age2;

        /// <summary>
        /// 距离上方多少空距离
        /// </summary>
        [Space(50)]
        public int Age3;

        /// <summary>
        /// 输入区域的高度
        /// </summary>
        [Multiline(10)]
        public string Content;

        /// <summary>
        /// 无限长字符串
        /// </summary>
        [TextArea]
        public string Content1;

        [Range(5,10)]
        public int Age4;

        /// <summary>
        /// MyAttribute的实际使用名字用My，MyAttribute只是它正常使用的名字
        /// </summary>
        [My]
        public int Age5;
    }
}