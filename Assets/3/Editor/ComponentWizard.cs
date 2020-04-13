using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

namespace HelloWorld
{
    public class ComponentWizard : ScriptableWizard 
    {
        private const string CodeTemplate =
@"using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace �����ռ�
{
    [GenerateAuthoringComponent]
    public struct ���� : IComponentData
    {

    }
}";

        public string className;

        [MenuItem("Assets/3/ComponentWizard", priority = 10000)]
        public static void ShowExample()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (Directory.Exists(path) == false) return;
            ScriptableWizard.DisplayWizard<ComponentWizard>("ComponentWizard", "Create");
        }

        private void OnWizardCreate()
        {
            CodeGenerateUtility.CreateCode(className, CodeTemplate);
        }
    }
}