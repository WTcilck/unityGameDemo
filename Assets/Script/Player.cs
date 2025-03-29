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
    private float restSuperWeaponTime;

    // 武器数量
    public int weaponCount = 1;
    public Gun gunTop;
    public Gun gunLeft;
    public Gun gunRight;

    public int hp;
    public int boomRestNum;
    public Text boomText;

    // public AudioSource[] audioList;

    void Awake() {
        gunTop = GameObject.Find("Gun Top").GetComponent<Gun>();
        gunLeft = GameObject.Find("Gun Left").GetComponent<Gun>();
        gunRight = GameObject.Find("Gun Right").GetComponent<Gun>();
        // audioList = GetComponents<AudioSource>();
        boomText = GameObject.Find("RestNum").GetComponent<Text>();
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
        boomText.text = "X 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Boom();
        }
        if (canPlayAnimation) {
            timer += Time.deltaTime;
            // 1/fps=一帧所需时间 (timer/一帧所需时间)再取整得到当前帧索引
            int frameIndex = (int)(timer / (1f / fps)) % 2;
            sr.sprite = sprites[frameIndex];
        }
        if (hp <= 0) {
            canPlayAnimation = false;
            timerExplode += Time.deltaTime;
            int frameIndex = (int)(timerExplode / (1f / fps)) % 4;
            sr.sprite = spritesExplode[frameIndex];

            if (frameIndex == spritesExplode.Length - 1) {
                GameManager._instance.gameState = GameState.End;
                DestroyAll();
                Time.timeScale = 0;
                Destroy(gameObject);
            }
        }

        targetDup = (Input.GetKey(keyUp) ? 1f : 0) - (Input.GetKey(keyDown) ? 1f : 0);
        targetDright = (Input.GetKey(keyRight) ? 1f : 0) - (Input.GetKey(keyLeft) ? 1f : 0);

        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);

        transform.Translate(new Vector3(Dright, Dup, transform.position.z) * moveSpeed * Time.deltaTime);

        // 防止飞出屏幕
        float x = Mathf.Clamp(transform.position.x, -1.8f, 1.8f);
        float y = Mathf.Clamp(transform.position.y, -3.66f, 3.66f);

        transform.position = new Vector3(x, y, transform.position.z);
        superWeaponTime -= Time.deltaTime;
        if (superWeaponTime > 0) {
            if (weaponCount == 1) {
                ToSuperWeapon();
                Debug.Log("双管齐发");
            }
        } else {
            if (weaponCount == 2) {
                ToNormalWeapon();
                Debug.Log("单管发射");
            }
        }
    }

    void ToSuperWeapon() {
        weaponCount = 2;
        gunTop.StopFire();
        gunRight.OpenFire();
        gunLeft.OpenFire();
    }

    void ToNormalWeapon() {
        weaponCount = 1;
        gunTop.OpenFire();
        gunRight.StopFire();
        gunLeft.StopFire();
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Award") {
            // audioList[0].Play();
            if (other.transform.GetComponent<Award>().type == 0) {
                superWeaponTime = restSuperWeaponTime;
            }
            if (other.transform.GetComponent<Award>().type == 1) {
                boomRestNum++;
                boomText.text = "X " + boomRestNum;
            }
            Destroy(other.gameObject);
        }
    }

    void DestroyAll() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            Destroy(enemy.gameObject);
        }
        GameObject[] awards = GameObject.FindGameObjectsWithTag("Award");
        foreach (GameObject award in awards) {
            Destroy(award.gameObject);
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets) {
            Destroy(bullet.gameObject);
        }
        Destroy(GameObject.Find("Spawn").gameObject);
    }

    void Boom() {
        boomRestNum--;
        boomText.text = "X " + boomRestNum;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in gos) {
            go.GetComponent<Enemy>().isDead = true;
        }
    }
}
