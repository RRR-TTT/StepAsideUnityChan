using UnityEngine;
using System.Collections;


public class ItemGenerator : MonoBehaviour {
	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//cornPrefabを入れる
	public GameObject conePrefab;
	//スタート地点
	private int startPos = -160;
	//ゴール地点
	private int goalPos = 120;
	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;

	private struct Item{
		public float x;			// レーン
		public float y;			// 
		public float z;			// アイテムの位置
		public float offset; 	// 次のアイテムを置く位置
		public int idx;			// アイテム種別  0:コーン, 1:何もなし, 2/3/4/5/6/7: コイン, 8,9,10:車 
	}
	public float lastGeneratedItemZPos = 0.0f;
	private const float visibleRange = 50.0f;

	// Use this for initialization
	void Start () {
		lastGeneratedItemZPos = startPos + 10.0f;
	}

	// Update is called once per frame
	void Update () {
		Item[] item = new Item[3];
		// Unityちゃんのオブジェクトの取得
		GameObject unityChan = GameObject.Find ("unitychan");
		float updateStartPos = unityChan.transform.position.z;
		while (lastGeneratedItemZPos < updateStartPos + visibleRange) {
			// スタートから一定距離はアイテムを生成しない
			if( unityChan.transform.position.z < startPos-50){
				break;
			}
			// ゴール一定距離手前からはアイテムを生成しない
			if (120 < lastGeneratedItemZPos+20) {
				break;
			}
			// 設置するアイテムを決定する
			bool isCone = Mathf.Round (Random.Range (0, 10)) < 1? true : false;
			if (isCone) { // Coneかどうか
				for(int i=0; i<3; i++){
					item [i].idx = 0;
				}
			} else { //Cone以外
				for (int i = 0; i < 3; i++) {
					item [i].idx = (int)Mathf.Round (Random.Range (1, 10));
				}
			}
			// Itemの位置を決定する
			float tmp_offset = Random.Range (5, 15);
			for (int i = 0; i < 3; i++) {
				item [i].offset = tmp_offset;
				item [i].x = (i - 1) * posRange;
				item [i].z = lastGeneratedItemZPos + item[i].offset;
			}
			// アイテムを描画する
			for (int i = 0; i < 3; i++) {
				switch (item [i].idx) {
				case 0: // Cone
					GameObject cone = Instantiate (conePrefab) as GameObject;
					cone.transform.position = new Vector3 (item [i].x, cone.transform.position.y, item [i].z);
					break;
				case 1: // 何もなし
					break;
				case 2: // コイン Fall Through
				case 3: // コイン Fall Through
				case 4: // コイン Fall Through
				case 5: // コイン Fall Through
				case 6: // コイン Fall Through
				case 7: // コイン
					GameObject coin = Instantiate (coinPrefab) as GameObject;
					coin.transform.position = new Vector3 (item[i].x, coin.transform.position.y, item[i].z);
					break;
				case 8: // 車 Fall Through
				case 9: // 車 Fall Through
				case 10: // 車
					GameObject car = Instantiate (carPrefab) as GameObject;
					car.transform.position = new Vector3 (item[i].x, car.transform.position.y, item[i].z);
					break;
				}
			}
			// 設置を終えたらアイテムの最終位置を更新
			lastGeneratedItemZPos += item[0].offset;
		}
	}
}