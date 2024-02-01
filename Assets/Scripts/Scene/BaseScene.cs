using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class BaseScene : MonoBehaviour
{
    public SceneType SceneType = SceneType.Unknown;
    protected bool _init = false;

    public void Awake()
    {
        Init();
    }

    protected virtual bool Init()
    {
        if (_init)
            return false;

        _init = true;
        Managers.Init();

        GameObject gameObject = GameObject.Find("EventSystem");
        if(gameObject == null)
        {
            // ���ҽ� �ҷ�����
            /*
            Managers.Resource.Instantiate("EventSystem", null, (gameObject) =>
            {
                gameObject.name = "@EventSystem";
            });
            */
        }

        return _init;
    }

    public virtual void Clear()
    {
        
    }
}
