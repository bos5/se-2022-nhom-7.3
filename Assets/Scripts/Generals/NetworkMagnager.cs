using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NetworkMagnager : MonoBehaviour {

    //public GameObject messageNetworkBox;
    //public GameObject messageRoomBox;
    public GameObject messageFindBox;
    public Transform tranSyncServer, tranSyncClient;
    public Image imageShowLive;
    public Camera cameraRender;
    private GameObject syncWrite, syncRead;

	void Awake()
    {
        Modules.networkManager = transform.gameObject;
    }

    void Start()
    {
        
    }

    public void KickPlayer()
    {
       
    }

    //void CheckoutMyRoom()
    //{
    //    if (PhotonNetwork.otherPlayers.Length == 0)
    //        PhotonNetwork.LeaveRoom();
    //    else Invoke("CheckoutMyRoom", 0.1f);
    //}

    public void DisconectNetwork()
    {
       
    }

    public void CancelRoom()
    {
       
    }

    public void StartGame()
    {
        
    }

    public void SyncAvatar()
    {
       
    }

    void OnCreatedRoom()//tao room
    {
        if (messageFindBox.GetComponent<MessageFindOpponent>().isClose)
        {
            CancelRoom();
            return;
        }
        Modules.listNamePlayer = new List<string>();
        Modules.listNamePlayer.Add(Modules.namePlayOnline);
        //messageNetworkBox.GetComponent<MessageNetwork>().ButtonCloseBox();
        //messageRoomBox.SetActive(true);
        //messageRoomBox.GetComponent<Animator>().SetTrigger("TriOpen");
        //messageRoomBox.GetComponent<MessageRoom>().CallStart();
        print("cretate");
    }

    void OnJoinedRoom()//vao room
    {
        
    }

    void OnLeftRoom()//neu chinh minh tu thoat ra
    {
        ResetRoom();
        print("left room");
    }

    public void ResetRoom()
    {
        if (syncWrite != null) Destroy(syncWrite);
        if (syncRead != null) Destroy(syncRead);
        cameraRender.gameObject.SetActive(false);
        Modules.listNamePlayer = new List<string>();
        //if (messageRoomBox.activeSelf)
        //    messageRoomBox.GetComponent<Animator>().SetTrigger("TriClose");
        if (Modules.startViewOnline && Modules.panelViewEnemy.activeSelf)
            Modules.panelViewEnemy.GetComponent<RunEffectViewEnemy>().StartView(false);
        Camera.main.GetComponent<PageMainGame>().buttonPause.GetComponent<ButtonStatus>().Enable();
        messageFindBox.SetActive(false);
    }

    /*void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)//xu ly ca 2 phia server va client
    {
        if (Modules.startViewOnline)
            Modules.panelViewEnemy.GetComponent<RunEffectViewEnemy>().StartView(true);
        CancelRoom();
        print("dis room");
    }*/

    void OnDisconnectedFromPhoton()//neu bi dis mang
    {
        if (Modules.startViewOnline)
            Modules.failNow++;
        ResetRoom();
        print("dis photon");
    }

    string ImportDataArray(List<string> listInput, string charSplit)
    {
        string result = "";
        for (int i = 0; i < listInput.Count; i++)
        {
            result += listInput[i];
            if (i < listInput.Count - 1) result += charSplit;
        }
        return result;
    }

    List<string> ExportDataArray(string dataInput, params char[] charSplit)
    {
        List<string> result = new List<string>();
        string[] data = dataInput.Split(charSplit);
        foreach (string str in data) result.Add(str);
        return result;
    }

}
