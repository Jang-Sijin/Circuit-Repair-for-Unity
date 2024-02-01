using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance = null;
    public static Managers Instance { get { return s_instance; } }

    private SceneManagerEx _scene = new SceneManagerEx();

    public static SceneManagerEx Scene => Instance?._scene;

    private void Awake()
    {
        Init();
    }

    public static void Init()
    {
        if(s_instance == null)
        {
            GameObject managersGameObject = GameObject.Find("@Managers");
            if (managersGameObject == null)
                managersGameObject = new GameObject { name = "@Managers" };

            s_instance = Utils.GetOrAddComponent<Managers>(managersGameObject);
            DontDestroyOnLoad(managersGameObject);

            // All Manager Init
        }
    }
}
