using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 武器类
public class Gun : MonoBehaviour
{
    public float fireSpeed = 1.0f;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire() {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    public void OpenFire() {
        InvokeRepeating("Fire", 0.5f, fireSpeed);
    }

    public void StopFire() {
        CancelInvoke("Fire");
    }
}
