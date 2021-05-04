using UnityEngine;
using System.Collections;
 
public abstract class MonoSingletion<T> : MonoBehaviour where T : MonoBehaviour {
 
    private static string rootName = "脚本";
    private static GameObject monoSingletionRoot;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
         monoSingletionRoot = GameObject.Find(rootName);
         instance = monoSingletionRoot.GetComponent<T>();
    }
 
    private static T instance;
    public static T Instance
    {
        get
        {
            if (monoSingletionRoot == null)
            {
                monoSingletionRoot = GameObject.Find(rootName);
            }
            if (instance == null)
            {
                instance = monoSingletionRoot.GetComponent<T>();
                if (instance == null) instance = monoSingletionRoot.AddComponent<T>();
            }
            return instance;
        }
    }
 
}