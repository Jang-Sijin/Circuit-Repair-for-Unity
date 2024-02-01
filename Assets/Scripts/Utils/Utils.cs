using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

// [유틸리티]
// 코드 사용 중 필요(유용한)한 메서드 모음집
public class Utils : MonoBehaviour
{
    // 첫 번째 인자 go 게임 오브젝트에
    // 1. 제네릭 T(템플릿)에 해당되는 컴포넌트가 있는 경우, T타입 컴포넌트를 찾아서 반환(return)
    // 2. 제네릭 T(템플릿)에 해당되는 컴포넌트가 없는 경우, T타입 컴포넌트를 추가(AddComponent) 후 반환(return)
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();

        if(component == null)       
            component = go.AddComponent<T>();

        return component;
    }
}
