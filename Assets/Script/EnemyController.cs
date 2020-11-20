using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private PlayerManager Player;
    private BulletPool BPool;
    private Rigidbody2D rb2d;

    public GameObject EnemyPref;
    private int Hp = 0;
    private int Power = 0;
    // Use this for initialization
    void Awake()
    {
        Player = GameObject.Find("HitBox").GetComponent<PlayerManager>();
        BPool = GameObject.Find("pool").GetComponent<BulletPool>();
        rb2d = GetComponent<Rigidbody2D>();
        Status(10, 1);
    }
    void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        if(Hp == 0)
        {
            Destroy(EnemyPref);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()//敵移動
    {
        transform.position = new Vector2(1,1);
    }

    void Status(int s_hp, int s_power)
    {
        Hp = s_hp;
        Power = s_power;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Hp--;
            Debug.Log("hit");
        }
    }
}
