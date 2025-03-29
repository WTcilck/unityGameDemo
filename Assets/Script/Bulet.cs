using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > 4.4f)
        {
            Destroy(gameObject);
        }
    }

    // 碰撞检测
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            if (!other.GetComponent<Enemy>().isDead) {
                // 没死调用中弹方法，怪物hp减少
                other.gameObject.SendMessage("BeHit");
                Destroy(gameObject);
            }
        }
    }
}
