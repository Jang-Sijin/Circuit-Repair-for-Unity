using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleSceneCube : MonoBehaviour
{
    void Start()
    {
        // DoTween을 사용하여 큐브를 지속적으로 회전시킴
        transform.DORotate(new Vector3(0f, 360f, 0f), 5f, RotateMode.WorldAxisAdd) // 2초 동안 360도 회전
            .SetLoops(-1) // 무한 반복
            .SetEase(Ease.Linear); // 회전 애니메이션의 이징 설정
    }
}