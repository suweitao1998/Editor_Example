using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

namespace HelloWorld
{
    public class AuthoringWizard : ScriptableWizard
    {
        private const string CodeTemplate =
@"using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace 命名空间
{
    [DisallowMultipleComponent]
    [RequiresEntityConversion]
    public class 类名 : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {

        }
    }
}";

        public string className;

        [MenuItem("Assets/3/AuthoringWizard", priority = 10001)]
        public static void ShowExample()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (Directory.Exists(path) == false) return;
            ScriptableWizard.DisplayWizard<AuthoringWizard>("AuthoringWizard", "Create");
        }

        private void OnWizardCreate()
        {
            CodeGenerateUtility.CreateCode(className, CodeTemplate);
        }
    }
}