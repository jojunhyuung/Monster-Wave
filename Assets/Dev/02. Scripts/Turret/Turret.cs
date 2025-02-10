using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Animator anim;
    public ParticleSystem ps;

    public Transform shootTf;
    
    private float timer;
    public float shootCooldown = 0.5f;
    
    public Transform currentTarget;
    public Transform headTf;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (currentTarget != null) // 타겟 있음
        {
            headTf.LookAt(currentTarget);
        }
        
        Shoot();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MONSTER"))
        {
            currentTarget = other.transform;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MONSTER"))
        {
            currentTarget = null;
        }
    }

    private void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= shootCooldown)
        {
            timer = 0f;
            ps.Play();
            anim.SetTrigger("Shoot");
            CreateBullet();
        }
    }

    private void CreateBullet()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, shootTf.position, Quaternion.identity);

        bulletObj.GetComponent<Rigidbody>().AddForce(shootTf.forward * 50f, ForceMode.Impulse);
    }

}