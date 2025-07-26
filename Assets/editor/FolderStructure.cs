using UnityEditor;
using UnityEngine;
using System.IO;

public class FolderStructure : MonoBehaviour
{
    [MenuItem("Tools/Create Initial Folder Structure")]
    public static void CreateFolders()
    {
        string[] folders = new string[]
        {
            "Assets/_Game",
            "Assets/_Game/Art",
            "Assets/_Game/Audio",
            "Assets/_Game/Materials",
            "Assets/_Game/Prefabs",
            "Assets/_Game/Scenes",
            "Assets/_Game/Scripts",
            "Assets/_Game/Animations",
            "Assets/_Game/Fonts",
            "Assets/_Game/SriptableObjects",
            "Assets/_Game/Resources",
            "Assets/_Game/UI",
            "Assets/Plugins",
            "Assets/Gizmos"
        };

        foreach (string folder in folders)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                Debug.Log("Created folder: " + folder);
            }
        }

        AssetDatabase.Refresh();
        Debug.Log("✅ Folder structure created successfully.");
    }
    
    [MenuItem("Tools/Create Script Folders")]
    public static void CreateScriptFolders()
    {
        string[] folders = new string[]
        {
            
            "Assets/_Game/Scripts/Core",
            "Assets/_Game/Scripts/Data",
            "Assets/_Game/Scripts/Gameplay",
            "Assets/_Game/Scripts/Interfaces",
            "Assets/_Game/Scripts/Interfaces",
            "Assets/_Game/Scripts/Util",
        };

        foreach (string folder in folders)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                Debug.Log("Created folder: " + folder);
            }
        }

        AssetDatabase.Refresh();
        Debug.Log("✅ Folder structure created successfully.");
    }
    
}