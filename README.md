# 【Unity】ニフクラmobile backend を体験しよう！
![画像1](/readme-img/001.png)

## 概要
* Unityで作成したiOSアプリから、[ニフクラmobile backend](https://mbaas.nifcloud.com/)へデータ登録を行うサンプアプリです

* 「START DEMO」ボタンをタップするとクラウドにデータが上がります★
* 簡単な操作ですぐに [ニフクラmobile backend](https://mbaas.nifcloud.com/)を体験いただけます

## ニフクラmobile backendって何？？
スマートフォンアプリのバックエンド機能（プッシュ通知・データストア・会員管理・ファイルストア・SNS連携・位置情報検索・スクリプト）が**開発不要**、しかも基本**無料**(注1)で使えるクラウドサービス！今回はデータストアを体験します

注1：詳しくは[こちら](https://mbaas.nifcloud.com/price.htm)をご覧ください

![画像2](/readme-img/002.png)

## 動作環境

* MacOS Mojave v10.15.6 (Catalina)
* Android studio 4.0
* LG V20 plus (OS 8.0)
* Xcode 11.6
* Unity 2020.1.8f1
* iphone 7 14.0

※上記内容で動作確認をしています。

## 手順
### 1. [ニフクラmobile backend](https://mbaas.nifcloud.com/)の会員登録とログイン→アプリ作成

* 上記リンクから会員登録（無料）をします。登録ができたらログインをすると下図のように「アプリの新規作成」画面が出るのでアプリを作成します

![画像3](/readme-img/003.png)

* アプリ作成されると下図のような画面になります
* この２種類のAPIキー（アプリケーションキーとクライアントキー）はUnityで作成するアプリに[ニフクラmobile backend](https://mbaas.nifcloud.com/)を紐付けるために使用します

![画像4](/readme-img/004.png)

* この後動作確認でデータが保存される場所も確認しておきましょう

![画像5](/readme-img/005.png)

### 2. [GitHub](https://github.com/NIFCLOUD-mbaas/Unity_DB_DEMO.git)からサンプルプロジェクトのダウンロード

* この画面([GitHub](https://github.com/NIFCLOUD-mbaas/Unity_DB_DEMO.git))の![画像10](/readme-img/010.png)ボタンをクリックし、さらに![画像14](/readme-img/014.PNG)ボタンをクリックしてサンプルプロジェクトをMacにダウンロードします

### 3. Unityでアプリを起動

ダウンロードしたフォルダを解凍し、Unityから開いてください。その後、Unity_DB_DEMOシーンを開いてください。

### 4. APIキーの設定

* Unity_DB_DEMOシーンのNCMBSettingsを編集します
* 先程[ニフクラmobile backend](https://mbaas.nifcloud.com/)のダッシュボード上で確認したAPIキーを貼り付けます

![画像07](/readme-img/007.png)

* それぞれ「Application Key」と「Client Key」のテキストフィールドに「アプリケーションキー」と「クライアントキー」を貼り付けます

### 5. 動作確認
* Unity画面で上部真ん中の実行ボタン（さんかくの再生マーク）をクリックします

![画像12](/readme-img/012.png)

* シミュレーターが起動したら![画像13](/readme-img/013.png)ボタンをタップします
* 動作結果が画面に表示されます
 * 保存に成功した場合：「`保存に成功しました。objectId : ******`」
 * 保存に失敗した場合：「`エラーが発生しました。ErrorCode : ******`」
* objectIdはデータを保存したときに自動で割り振られるIDです
* 万が一エラーが発生した場合は、[こちら](https://mbaas.nifcloud.com/doc/current/rest/common/error.html)よりエラー内容を確認いただけます
![画像1](/readme-img/001.png)

* 保存に成功したら、[ニフクラmobile backend](https://mbaas.nifcloud.com/)のダッシュボードから「データストア」を確認してみましょう！
* `TestClass`という保存用クラスが作成され、その中にデータが確認できます

##### iOS端末へのビルド

* iOSビルド手順は以下のとおりです。  
iOS端末でビルドを行うには、Unityで.xcodeprojファイルを作成します。
- 「Build Settings」へ戻り、Platformで「iOS」を選択 -> 「Switch Platform」をクリックします。

<img src="readme-img/unity_ios_00001.png" width="700" alt="iOS" />


- ボタンが「Build」に変わったらクリックします。アプリ名を入力するとビルドが開始されるので、完了したらXcodeで開いてください。

- XcodeでPush Notificationの追加とプロビジョニングファイルの設定を行う必要があります。[iOSのドキュメント](https://mbaas.nifcloud.com/doc/current/push/basic_usage_ios.html#Xcodeでの対応)の「5.1 Xcodeでの対応」を実装してください。


###### Xcodeの追加設定

  * iOSであり、Unity SDK v4.0.4以上の場合、Xcode側にて「WebKit.framework」「UserNotifications.framework」を追加する必要があります。
  * Xcodeで「Unity-iPhone」-> General -> TARGETで「UnityFramework」を選択します。追加されているライブラリ一覧の下にある「＋」をクリックします。
  <img src="readme-img/add_frameworks_UnitySDK4.0.4.png" width="612"  alt="フレームワークの追加" />
  * 検索窓にて「Web」と入力し、「WebKit.framework」があるので選択しAddをクリックします。

<img src="readme-img/Webview_flow2.png" width="420" height="480" alt="リッチプッシュ設定方法2" />

* 「UserNotifications.framework」ライブラリも同じように検索して追加します

<img src="readme-img/unity_ios_00003.png" width="420" alt="iOS" />

ライブラリ一覧に追加されていることが確認できれば設定完了です。

※注意１: Unity SDK v4.2.0以上を使用している場合、上の２つに加えて「AuthencationServices.framework」も追加する必要があります。

<img src="readme-img/xcode_settings_005.png" width="680px;"/>

* 「Build Phases」 タブで「AuthenticationServices.framework」を「Optional」にします。  
<img src="readme-img/optional_AuthenticationServices.framework.png" width="680px;"/>

※注意２： Unity 2019.3未満の場合は、以下の画像のように TARGET->「Unity-iPhone」でフレームワークを追加するようにしてください。
こちらも「WebKit.framework」「UserNotifications.framework」「AuthenticationServices.framework」を追加する必要があります。

<img src="readme-img/target_Unity-iPhone.png" width="200px;"/>

- 上記が完了しましたら、iOS動作確認は可能となります。

## 解説
サンプルプロジェクトに実装済みの内容のご紹介

#### SDKのインポートと初期設定
* ニフクラmobile backend の[ドキュメント（クイックスタート）](https://mbaas.nifcloud.com/doc/current/introduction/quickstart_unity.html)にドキュメントをご用意していますので、ご活用ください

#### ロジック
 * Hierarchy内の`Canvas`でUIをデザインし、`Unity_DB_DEMO.cs`にロジックを書いています
 * `testClass`オブジェクトに対してkey, value形式で値をセットし、`saveInBackgroundWithBlock`メソッドを実行すると、非同期にてデータが保存されます

```csharp
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
```

## 参考
* 会員管理のコンテンツもご用意しています
 * https://github.com/NIFCLOUD-mbaas/UnityLoginApp
