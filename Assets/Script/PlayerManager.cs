using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour {
    public float playerSpeed;//移動速度
    public int remain = 3;//残機
    public int Remain {
        //外部用変数
        get {return remain;}
        set {remain = value;}
    }
    public int power;//弾丸の威力
    public float ShotDelay = 0f;//発射ディレイ
    public bool BulletShot = false; //打つか打たないか切り替え
    public bool dead = false; //死んだ判定
    private bool invincibleTime = false;

    private float vecx = 0;
    private float vecy = 0;
	private new Camera camera;
    private BulletPool Bpool;
    private GameObject canvas;
    private UI_Manager uim;
    public GameObject bulletPref;


    // Use this for initialization
    void Awake()
    {
        GameObject obj = GameObject.Find("MainCamera");
        camera = obj.GetComponent<Camera>();
        canvas = GameObject.Find("Canvas");
        uim = canvas.GetComponent<UI_Manager>();
    }
    void Start()
    {
        //プールへの参照を保存
        //Bpool = GameObject.Find("pool").GetComponent<BulletPool>();
        // 弾を打つコルーチンを呼び出す
        StartCoroutine(Shot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        playerControll();
    }

    public void playerControll()
    {
        vecx = 0;
        vecy = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vecx = -playerSpeed;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            vecx = playerSpeed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vecy = playerSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vecy = -playerSpeed;
        }
        transform.Translate(vecx / 50, vecy / 50, 0);
		transform.position = (new Vector3(
                Mathf.Clamp(transform.position.x, getScreenTopLeft().x, -getScreenTopLeft().x),
                Mathf.Clamp(transform.position.y, getScreenBottomRight().y, -getScreenBottomRight().y),0));
        if (Input.GetKey(KeyCode.X)) { BulletShot = true; }
        else { BulletShot = false; }

            
    }
    /*
    IEnumerator ShotBullet()
    {
        while (true)
        {
            // 弾を撃つ処理を呼んで
            Shot();
            // shotDelay秒待つ
            yield return new WaitForSeconds(ShotDelay);
        }
    }
    private void Shot()
    {
        if (BulletShot)
        {
            var bullet = Bpool.GetBullet();
            bullet.transform.localPosition = tf.position;
        }
        else return;
    }
    */
    IEnumerator Shot()
	{
		while(true)
		{
			BulletInstance();
			yield return new WaitForSeconds(ShotDelay);
		}
	}

    IEnumerator WaitForIt()
    {
        invincibleTime = true;
        Remain --;
        uim.Remain_.text = Remain.ToString();
        transform.position = new Vector2(-5.8f,-0.5f);

        yield return new WaitForSeconds(3f);
        invincibleTime = false;
        StopCoroutine("WaitForIt");
    }
    
	private Vector3 getScreenTopLeft()
    {
        // 画面の左上を取得
        Vector3 topLeft = camera.ScreenToWorldPoint(Vector3.zero);
        // 上下反転させる
        topLeft.Scale(new Vector3(1f, -1f, 1f));
        return topLeft;
    }

    private Vector3 getScreenBottomRight()
    {
        // 画面の右下を取得
        Vector3 bottomRight = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        // 上下反転させる
        bottomRight.Scale(new Vector3(1f, -1f, 1f));
        return bottomRight;
    }

    void IsDead()
    {
        //StopCoroutine(ShotBullet());
        StopCoroutine(Shot());
        SceneManager.LoadScene("Game_Over");
    }
    void BulletInstance()
	{
		if(BulletShot) {
            Instantiate(bulletPref, transform.position, Quaternion.identity);
        }
	}


    void OnTriggerEnter2D(Collider2D c2d)
    {
        
        if(c2d.gameObject.CompareTag("Enemy")) { dead = true; }
        if(c2d.gameObject.CompareTag("Enemy") && remain <= 0 && dead)
        {
            IsDead();
        }
        else if(c2d.gameObject.CompareTag("Enemy") && remain > 0 && dead)
        {
            if(!invincibleTime){StartCoroutine("WaitForIt");}
        }
    }
}
