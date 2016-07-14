using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using NCMB;

public class Unity_DB_DEMO : MonoBehaviour {
	public Text result;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Start_Demo(){
		// クラスのNCMBObjectを作成
		NCMBObject testClass = new NCMBObject("TestClass");

		// オブジェクトに値を設定
		testClass["message"] = "Hello, NCMB!";

		// データストアへの登録
		testClass.SaveAsync((NCMBException e) => { 
				if (e != null) {
					result.text += "保存に失敗しました。\n ErrorCode : " + (string)e.ErrorMessage+ "\n";
					UnityEngine.Debug.Log ("保存に失敗: " + e.ErrorMessage);
				} else {
					result.text += "保存に成功しました。\n objectId : " + (string)testClass.ObjectId + "\n";
					UnityEngine.Debug.Log ("保存に成功");
				}
			}
		
		);

	}
}
