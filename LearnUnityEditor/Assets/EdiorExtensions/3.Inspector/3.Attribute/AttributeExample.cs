using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorExtensions
{
    /// <summary>
    /// �ű�����������Ҳ�Բ���ʺŵ���������ĵ�ַ
    /// </summary>
    [HelpURL("https://unity.cn")]
    public class AttributeExample : MonoBehaviour
    {

        public int Age;

        [HideInInspector]
        public int Age1;

        [Header("����")]
        [SerializeField]
        private int Age2;

        /// <summary>
        /// �����Ϸ����ٿվ���
        /// </summary>
        [Space(50)]
        public int Age3;

        /// <summary>
        /// ��������ĸ߶�
        /// </summary>
        [Multiline(10)]
        public string Content;

        /// <summary>
        /// ���޳��ַ���
        /// </summary>
        [TextArea]
        public string Content1;

        [Range(5,10)]
        public int Age4;

        /// <summary>
        /// MyAttribute��ʵ��ʹ��������My��MyAttributeֻ��������ʹ�õ�����
        /// </summary>
        [My]
        public int Age5;
    }
}