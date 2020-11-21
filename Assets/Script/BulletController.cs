using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private const int Bspeed = 20;//弾の速さ
    private float _screenRight;// 画面の一番上のy座標。画面外かどうかの判定に使用

    private Rigidbody2D rb2d;
    private Transform tf;
    public GameObject Enemy;
    public GameObject BulletPref;

	// Use this for initialization
	void Start () {
		
	}

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();

        // 画面の一番右の座標
        _screenRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        // 弾を右に移動させる
        rb2d.velocity = tf.right.normalized * Bspeed;
    }

    // Update is called once per frame
    void Update () {

        // Rigidbody2Dのsimulatedがfalse(弾が使われていない状態)であれば何もしない
        if (rb2d.simulated == false) { rb2d.position = new Vector2(_screenRight + 1, rb2d.position.y); }
        if (tf.position.x > _screenRight + 1)
        {
            rb2d.simulated = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            rb2d.position = new Vector2(_screenRight + 1, rb2d.position.y);
            rb2d.velocity = Vector2.zero;
        }
    }

}
