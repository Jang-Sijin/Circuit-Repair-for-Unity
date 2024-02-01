using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    private Define.SceneType _currentSceneType = Define.SceneType.Unknown;

    public Define.SceneType CurrentSceneType
    {
        get => _currentSceneType != Define.SceneType.Unknown ? _currentSceneType : CurrentScene.SceneType;
        set => _currentSceneType = value;
    }

    public BaseScene CurrentScene => GameObject.FindObjectOfType<BaseScene>();


    // 현재 씬에서 다음 씬으로 이동.
    public void ChangeScene(Define.SceneType type)
    {
        Debug.Log(CurrentScene);
        CurrentScene.Clear();

        _currentSceneType = type;
        SceneManager.LoadSceneAsync(GetSceneName(type));
    }

    // 씬 이름 첫 글자는 대문자로, 나머지 글자는 소문자로 string으로 반환.
    private string GetSceneName(Define.SceneType type)
    {//
        string name = System.Enum.GetName(typeof(Define.SceneType), type);
        char[] letter = name.ToLower().ToCharArray();
        letter[0] = char.ToUpper(letter[0]);
        return new string(letter);
    }
}
