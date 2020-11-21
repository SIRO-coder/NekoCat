using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {

    [SerializeField]
    private GameObject poolObject;
    public List<GameObject> poolObjectL { get; set; }

    private const int MaxCount = 20;
    // Use this for initialization
    void Awake()
    {
        CreatePool();
    }
	private void CreatePool()
    {
        poolObjectL = new List<GameObject>();
        for(int i = 0; i < MaxCount; i++)
        {
            var newObj = CreateNewBullet();// 弾を生成して
            newObj.GetComponent<Rigidbody2D>().simulated = false;// 物理演算を切って(=未使用にして)
            poolObjectL.Add(newObj); // リストに保存しておく

        }
    }

    // 未使用の弾を探して返す処理
    // 未使用のものがなければ新しく作って返す
    public GameObject GetBullet()
    {
        //使用中でないものを探して返す
        foreach (var obj in poolObjectL)
        {
            var objrb = obj.GetComponent<Rigidbody2D>();
            if(objrb.simulated == false)
            {
                objrb.simulated = true;
                return obj;
            }
        }

        // 全て使用中だったら新しく作り、リストに追加してから返す
        var newObj = CreateNewBullet();
        poolObjectL.Add(newObj);

        newObj.GetComponent<Rigidbody2D>().simulated = true;
        return newObj;
    }

    private GameObject CreateNewBullet()
    {
        var pos = new Vector2(100, 100);// 画面外であればどこでもOK
        var newObj = Instantiate(poolObject, pos, Quaternion.identity); // 弾を生成しておいて
        newObj.name = poolObject.name + (poolObjectL.Count + 1); // 名前を連番でつけてから

        return newObj; // 返す
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
    
}
