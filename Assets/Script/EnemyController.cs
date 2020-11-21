using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private PlayerManager Player;
    private BulletPool BPool;
    private Rigidbody2D rb2d;
    public GameObject EnemyPref;
    private Transform tf;
    System.Random random = new System.Random();
    private int Hp = 0;
    private int Power = 0;
    private float _screenLeft;
    // Use this for initialization
    void Awake()
    {
        Player = GameObject.Find("HitBox").GetComponent<PlayerManager>();
        BPool = GameObject.Find("pool").GetComponent<BulletPool>();
        rb2d = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        _screenLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        Status(random.Next(3,15), 1);
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
        rb2d.velocity = new Vector2(random.Next(-15,-5), rb2d.velocity.y);
        
        if(tf.position.x < _screenLeft - 1) 
        {
            rb2d.simulated = false; 
            Destroy(EnemyPref);
        }
        else {return;}
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
