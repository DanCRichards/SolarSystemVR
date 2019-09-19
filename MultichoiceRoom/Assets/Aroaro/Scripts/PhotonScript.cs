using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//public class PhotonScript : MonoBehaviourPunCallbacks
//{
//    void Start()
//    {
//        PhotonNetwork.ConnectUsingSettings();
//        Debug.Log("Connecting...");
//    }
//    public override void OnConnectedToMaster()
//    {
//        base.OnConnectedToMaster();
//        Debug.Log("Connected to Master");

//    }
//}
//public class PhotonScript : MonoBehaviourPunCallbacks
//{
//    void Start()
//    {
//        PhotonNetwork.ConnectUsingSettings();
//        Debug.Log("Connecting...");
//    }
//    public override void OnConnectedToMaster()
//    {
//        base.OnConnectedToMaster();
//        Debug.Log("Connected to Master");

//        PhotonNetwork.JoinOrCreateRoom("HardCodedRoom", null, null);
//    }
//    public override void OnJoinedRoom()
//    {
//        base.OnJoinedRoom();
//        Debug.Log("Joined Room");
//    }
//    public override void OnCreatedRoom()
//    {
//        base.OnCreatedRoom();
//        Debug.Log("Created Room");

//    }
//}
public class PhotonScript : MonoBehaviourPunCallbacks
{
    enum RoomStatus
    {
        None,
        CreatedRoom,
        JoinedRoom
    }

    public int emptyRoomTimeToLiveSeconds = 120;

    RoomStatus roomStatus = RoomStatus.None;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        var roomOptions = new RoomOptions();
        roomOptions.EmptyRoomTtl = this.emptyRoomTimeToLiveSeconds * 1000;
        PhotonNetwork.JoinOrCreateRoom(ROOM_NAME, roomOptions, null);
    }
    public async override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        if (this.roomStatus == RoomStatus.None)
        {
            this.roomStatus = RoomStatus.JoinedRoom;
        }
    }
    public async override void OnCreatedRoom()
    {
        base.OnCreatedRoom();

        this.roomStatus = RoomStatus.CreatedRoom;
    }
    static readonly string ROOM_NAME = "HardCodedRoomName";
}
