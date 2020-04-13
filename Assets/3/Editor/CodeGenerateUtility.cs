using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

namespace HelloWorld
{
    public static class CodeGenerateUtility 
    {
        public static void CreateCode(string className, string codeTemplate)
        {
            string overrideNamespace = EditorPrefs.GetString("OverrideMonoBehaviour_Namespace", null);
            if (overrideNamespace == null) return;
            if (string.IsNullOrWhiteSpace(className)) return;
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            string filePath = $"{path}/{className}.cs";
            using (FileStream fs = File.OpenWrite(filePath))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    string code = codeTemplate.Replace("命名空间", overrideNamespace);
                    code = code.Replace("类名", className);
                    sw.Write(code);
                }
            }
            AssetDatabase.Refresh();
        }
    }
}