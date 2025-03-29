using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // 生成游戏敌人和道具的对象
    public GameObject enemy0;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject award0;
    public GameObject award1;

    // 对应的生成速率
    public float rateOfCreateEnemy0;
    public float rateOfCreateEnemy1;
    public float rateOfCreateEnemy2;
    public float rateOfCreateAward0;
    public float rateOfCreateAward1;


    // Start is called before the first frame update
    void Start()
    {
        // 定时器 方法名，第一次调用时间s，间隔时间s
        InvokeRepeating("CreateEnemy0", 1, rateOfCreateEnemy0);
        InvokeRepeating("CreateEnemy1", 3, rateOfCreateEnemy1);
        InvokeRepeating("CreateEnemy2", 6, rateOfCreateEnemy2);

        InvokeRepeating("CreateAward0", 7, rateOfCreateAward0);
        InvokeRepeating("CreateAward1", 10, rateOfCreateAward1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateEnemy0() {
        float x = Random.Range(-2f, 2f);
        Instantiate(enemy0, new Vector3(x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    public void CreateEnemy1() {
        float x = Random.Range(-2f, 2f);
        Instantiate(enemy1, new Vector3(x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    public void CreateEnemy2() {
        float x = Random.Range(-1.5f, 1.5f);
        Instantiate(enemy2, new Vector3(x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    public void CreateAward0() {
        float x = Random.Range(-1.5f, 1.5f);
        Instantiate(award0, new Vector3(x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    public void CreateAward1() {
        float x = Random.Range(-1.5f, 1.5f);
        Instantiate(award1, new Vector3(x, transform.position.y, transform.position.z), Quaternion.identity);        
    }
}
