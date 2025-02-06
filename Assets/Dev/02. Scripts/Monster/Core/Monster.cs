using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public float speed;
    public float hp;

    protected abstract void Init();
    
    void Start()
    {
        Init();
    }

    void Update()
    {
        Move();
    }

    void OnMouseDown()
    {
        Hit(1);
    }
    
    protected virtual void Hit(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            this.GetComponent<Animator>().SetBool("dead", true);
        }

    }
    
    protected void Move()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}