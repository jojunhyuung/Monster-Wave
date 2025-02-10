using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator anim;

    public float speed;
    public float hp;

    public bool isMove = true;
    
    protected virtual void Init()
    {
        anim = GetComponent<Animator>();
    }
    
    void Start()
    {
        Init();

        // anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void OnMouseDown()
    {
        Hit(1);
    }

    public void OnHit(float damage)
    {
        Hit(damage);
    }
    
    protected virtual void Hit(float damage)
    {
        hp -= damage;
        isMove = false;

        if (hp <= 0)
        {
            anim.SetTrigger("dead");
            this.GetComponent<Collider>().enabled = false;
            Destroy(this.gameObject, 5f);
        }
        else
        {
            anim.SetTrigger("hit");
            Invoke("DelayMove", 0.5f);
        }
    }

    private void DelayMove()
    {
        isMove = true;
    }
    
    protected void Move()
    {
        if (isMove)
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}