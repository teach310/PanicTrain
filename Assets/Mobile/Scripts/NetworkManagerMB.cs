using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkManagerMB : Photon.MonoBehaviour {

	private MySceneManager _mySceneManager;
	public Text _textConnectionState;

	void Awake()
	{
		_mySceneManager = GameObject.Find ("MySceneManager").GetComponent<MySceneManager> ();
		if(_textConnectionState == null)
			_textConnectionState = GameObject.Find ("TextConnectionState").GetComponent<Text> ();
		
		// 接続
		PhotonNetwork.ConnectUsingSettings ("v0.1");
	}

	void Update(){
		if(_textConnectionState)
			_textConnectionState.text = PhotonNetwork.connectionStateDetailed.ToString ();
	}

	void SearchRoom(){
		Debug.Log ("Search Room");
		PhotonNetwork.JoinRandomRoom ();
	}

	// 接続できたら一旦ルームを探してみる
	void OnJoinedLobby()
	{
		Debug.Log ("aa");
		PhotonNetwork.JoinRandomRoom ();
	}

	// RandomJoinできなかったら待機
	void OnPhotonRandomJoinFailed()
	{
		Debug.Log ("RoomJoin Failed");
//		RoomOptions roomOptions = new RoomOptions ();
//		roomOptions.isVisible = true;
//		roomOptions.isOpen = true;
//		roomOptions.maxPlayers = 2;
//		PhotonNetwork.CreateRoom("")
		Invoke("SearchRoom",2.0f);
	}

	void OnJoinedRoom()
	{
		Debug.Log ("Room Join");
	}

	[PunRPC]
	void SetCurrentStateRPC(MySceneManager.SceneState state)
	{
		_mySceneManager.SetCurrentScene (state);
	}


}
