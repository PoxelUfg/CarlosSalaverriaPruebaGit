using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.XR;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text roomName;
    [SerializeField] TMP_Text ErrorMessage;

    private void Start()
    {
        Debug.Log("Conectando");

        PhotonNetwork.ConnectUsingSettings();

        MenuManager.instance.OpenMenuName("Loading");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectando");
        PhotonNetwork.JoinLobby();
    }
 
    public override void OnJoinedLobby()
    {
        Debug.Log("Conectando al lobby");
        MenuManager.instance.OpenMenuName("Home");
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }

        PhotonNetwork.CreateRoom(roomNameInputField.text);

        MenuManager.instance.OpenMenuName("Loading");
    }

    public override void OnJoinedRoom()
    {
        MenuManager.instance.OpenMenuName("Room");
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        ErrorMessage.text = "Error al crear Sala" + message;
        MenuManager.instance.OpenMenuName("Error");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.instance.OpenMenuName("Loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.instance.OpenMenuName("Home");
    }
}
