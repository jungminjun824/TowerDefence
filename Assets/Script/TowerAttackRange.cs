using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TowerAttackRange : MonoBehaviour
{

    public void OnAttackRnage(Vector3 position, float range)
    {
        gameObject.SetActive(true);

        // 공격 범위 크기
        float diameter = range * 2.0f;
        transform.localScale = Vector3.one * diameter;

        transform.position = position;
    }

    public void OffAttackRange()
    {
        gameObject.SetActive(false);
    }
}
