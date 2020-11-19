using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private const int Bspeed = 20;//弾の速さ
    private float _screenRight;// 画面の一番上のy座標。画面外かどうかの判定に使用

    private Rigidbody2D rb2d;
    private Transform tf;

    public GameObject Enemy;

	// Use this for initialization
	void Start () {
		
	}

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();

        // 画面の一番上のy座標を取得
        _screenRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        // 弾を上に移動させる
        rb2d.velocity = tf.right.normalized * Bspeed;
    }

    // Update is called once per frame
    void Update () {

        // Rigidbody2Dのsimulatedがfalse(弾が使われていない状態)であれば何もしない
        if (rb2d.simulated == false) { return; }
        // ここからはRigidbody2Dのsimulatedがtrueの場合(=弾が動いている場合)
        // 画面外に弾が出ていたらRigidbody2Dのsimulatedをfalseにして物理演算を止める(弾をストップする)
        // ＋１しているのは余裕を持っているだけです。
        if (tf.position.x > _screenRight + 1)
        {
            rb2d.simulated = false;
        }
    }

}
