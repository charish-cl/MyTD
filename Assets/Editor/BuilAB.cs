using System.IO;
using UnityEditor;
using UnityEngine;
 
public class BuildAB : MonoBehaviour {
 
    //[MenuItem("AssetBundle/Package (Default)")]
    [MenuItem("AB/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}