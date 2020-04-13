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

namespace 命名空间
{
    [GenerateAuthoringComponent]
    public struct 类名 : IComponentData
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