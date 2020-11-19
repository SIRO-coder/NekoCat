using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    //敵プレファブ
    public GameObject enemyPref;
    //敵スポーンインターバル
    private float interval;
    //時間計測
    private float time = 0;
    // Use this for initialization
    void Start () {
        interval = 3f;
    }
	
	// Update is called once per frame
	void Update () {
        SpawnEnemy();
    }
    void FixedUpdate() {

    }

    private void SpawnEnemy() {
        System.Random random = new System.Random();
        time += Time.deltaTime;
        if (time > interval) {
            GameObject enemy = Instantiate(enemyPref);
            enemy.transform.position = new Vector2(10, random.Next(0, 5));
            time = 0;
            interval = random.Next(0, 5);
            Debug.Log("Spawn");
        }
    }
}
