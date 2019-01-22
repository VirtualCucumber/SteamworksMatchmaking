using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facepunch.Steamworks;

public class SteamNetworking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Client.Instance.Lobby.OnLobbyCreated += OnLobbyCreatedCallback;
        Client.Instance.LobbyList.OnLobbiesUpdated += OnLobbiesUpdatedCallback;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Trying to create a lobby...");
            Client.Instance.Lobby.Create(Lobby.Type.Public, 10);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Trying to get list of lobbies...");
            Client.Instance.LobbyList.Refresh();
        }

    }

    void OnLobbyCreatedCallback(bool success)
    {
        if (success)
            Debug.Log(Client.Instance.Lobby.Owner + " created a lobby");
        else
            Debug.Log("Lobby creation failed");
    }

    void OnLobbiesUpdatedCallback()
    {
        Debug.Log("Active lobbies = " + Client.Instance.LobbyList.Lobbies.Count);
    }
}
