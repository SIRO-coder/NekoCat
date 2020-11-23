using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBullet : MonoBehaviour {

	public GameObject bulletPref;
	private Rigidbody2D rb2d;
    private Transform tf;
	private const int Bspeed = 30;//弾の速さ
    private float _screenRight;// 画面の一番上のy座標。画面外かどうかの判定に使用

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
		// 画面の一番右の座標
        _screenRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        // 弾を右に移動させる
        rb2d.velocity = tf.right.normalized * Bspeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(tf.position.x > _screenRight + 1)
		{
			Destroy(bulletPref);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(bulletPref);
	}

}
