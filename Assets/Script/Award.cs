using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Award : MonoBehaviour
{
    // 0 gun    1 boom
    public int type;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        // GetComponent<AudioSource>().Player();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        if (transform.position.y < -4.8f)
        {
            Destroy(gameObject);
        }
    }
}
