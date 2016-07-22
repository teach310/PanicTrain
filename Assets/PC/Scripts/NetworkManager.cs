using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// NetworkManager for PC
/// </summary>
public class NetworkManager : Photon.MonoBehaviour {

	private MySceneManager _mySceneManager;
	public Text _textConnectionState;
	private Room _room;

	void Awake()
	{
		_mySceneManager = GameObject.Find ("MySceneManager").GetComponent<MySceneManager> ();
//		if(_textConnectionState == null)
//			_textConnectionState = GameObject.Find ("TextConnectionState").GetComponent<Text> ();
		PhotonNetwork.ConnectUsingSettings ("v0.1");
	}

	void Update () {
		if (PhotonNetwork.inRoom) {
			if (_room == null)
				return;
		}
			
		if(_textConnectionState)
			_textConnectionState.text = PhotonNetwork.connectionStateDetailed.ToString ();
	}

	void OnJoinedLobby()
	{
		RoomOptions roomOptions = new RoomOptions ();
		roomOptions.isVisible = true;
		roomOptions.isOpen = true;
		roomOptions.maxPlayers = 2;
		PhotonNetwork.CreateRoom ("PanicTrain", roomOptions, null);
	}

	void OnJoinedRoom()
	{
		Debug.Log ("Room Join");
		_room = PhotonNetwork.room;
	}

	[PunRPC]
	void SetCurrentStateRPC(MySceneManager.SceneState state)
	{
		_mySceneManager.SetCurrentScene (state);
		if (PhotonNetwork.isMasterClient && state == MySceneManager.SceneState.GAME) {
			_room.visible = false;
			_room.open = false;
		}
	}
}
