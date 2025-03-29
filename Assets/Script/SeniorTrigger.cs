using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeniorTrigger : MonoBehaviour
{
    public Player player;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        hpText = GameObject.Find("HP").GetComponent<Text>();
        hpText.text = "HP: " + player.hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        // 监听碰撞事件
        if (other.tag == "Enemy") {
            player.hp -= 1;
            hpText.text = "HP: " + player.hp.ToString();

            other.gameObject.SendMessage("BeHit");
        }
    }
}
