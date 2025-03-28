using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    // 输入信号值
    public float Dup;
    public float Dright;

    // 平滑输入值
    private float targetDup;
    private float targetDright;
    private float velocityDup;
    private float velocityDright;

    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";

    // 是否播放动画
    public bool canPlayAnimation;

    public int fps = 10;

    public float timer = 0;
    public float timerExplode = 0;
    // 正常存货的图片
    public Sprite[] sprites;
    // 死亡爆炸图片
    public Sprite[] spritesExplode;

    // 动画播放器
    public SpriteRenderer sr;

    // 大招冷却时间
    public float superWeaponTime = 15;
    public float restSuperWeaponTime;

    // 武器数量
    public int weaponCount = 1;
    public Gun gunTop;
    public Gun gunLeft;
    public Gun gunRight;

    public int hp;
    public int boomRestNum;
    // public Text boomText;

    public AudioSource[] audioList;

    void Awake() {
        gunTop = GameObject.Find("Gun Top").GetComponent<Gun>();
        gunLeft = GameObject.Find("Gun Left").GetComponent<Gun>();
        gunRight = GameObject.Find("Gun Right").GetComponent<Gun>();
        audioList = GetComponents<AudioSource>();
        // boomText = GameObject.Find("BoomText").GetComponent<Text>();
        Dup = 0;
        Dright = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        gunTop.OpenFire();
        canPlayAnimation = true;
        sr = GetComponent<SpriteRenderer>();
        restSuperWeaponTime = superWeaponTime;
        superWeaponTime = 0;
        boomRestNum = 0;
        // boomText.Text = "X 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            
        }
    }

    void Boom() {
        boomRestNum--;
        
    }
}
