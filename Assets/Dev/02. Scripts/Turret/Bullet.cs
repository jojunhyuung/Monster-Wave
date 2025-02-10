using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MONSTER"))
        {
            // 몬스터에게 데미지 적용
            other.GetComponent<Monster>().OnHit(1);
        }
    }
}