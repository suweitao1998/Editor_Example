using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

namespace HelloWorld
{
    public class SystemWizard : ScriptableWizard
    {
        private const string CodeTemplate =
@"using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace 命名空间
{
    public class 类名 : SystemBase
    {
        protected override void OnUpdate()
        {

        }
    }
}";

        public string className;

        [MenuItem("Assets/3/SystemWizard", priority = 10002)]
        public static void ShowExample()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (Directory.Exists(path) == false) return;
            ScriptableWizard.DisplayWizard<SystemWizard>("SystemWizard", "Create");
        }

        private void OnWizardCreate()
        {
            CodeGenerateUtility.CreateCode(className, CodeTemplate);
        }
    }
}