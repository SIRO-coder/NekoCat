using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public GameObject EnemyPref;
    private Transform tf;
    private GameObject canvas;
    private UI_Manager uI_Manager;
    System.Random random = new System.Random();
    private int Hp = 0;
    private int Power = 100;
    private float _screenLeft;
    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        canvas = GameObject.Find("Canvas");
        uI_Manager = canvas.GetComponent<UI_Manager>();
        _screenLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        Status(random.Next(3,7), 1);
    }
    void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        if(Hp == 0)
        {
            uI_Manager.score += random.Next(500, 2000);
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
    }

    void Status(int s_hp, int s_power)
    {
        Hp = s_hp;
        Power = s_power;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Hp--;
            Debug.Log("hit");
        }
    }
}
