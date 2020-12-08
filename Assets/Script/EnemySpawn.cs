using UnityEngine;
using System.Collections;
public class EnemySpawn : MonoBehaviour {

    //敵プレファブ
    public GameObject enemyPref;
    private long EnemyCount;
    //敵スポーンインターバル
    private float interval;
    //時間計測
    private float time = 0;
    //乱数生成
    System.Random random = new System.Random();
    // Use this for initialization
    void Start () {
        interval = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        SpawnEnemy();
    }
    void FixedUpdate() {

    }

    private void SpawnEnemy() {
        time += Time.deltaTime;
        if (time > interval) {
            EnemyCount++;
            GameObject enemy = Instantiate(enemyPref);
            enemy.name = enemyPref.name + (" " + EnemyCount.ToString());
            enemy.transform.position = new Vector2(10, random.Next(-4, 6));
            time = 0;
            interval = random.Next(0, 4);
        }
    }
}
