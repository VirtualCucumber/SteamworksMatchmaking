using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Facepunch.Steamworks;

public class SteamClient : MonoBehaviour
{
    public uint AppId;

    private Client client;

    private void Awake()
    {
        // Create the client
        client = new Client(AppId);
    }

    void Start()
    {
        // keep us around until the game closes
        GameObject.DontDestroyOnLoad(gameObject);

        if (AppId == 0)
            throw new System.Exception("You need to set the AppId to your game");

        //
        // Configure us for this unity platform
        //
        Config.ForUnity(Application.platform.ToString());



        if (!client.IsValid)
        {
            client = null;
            Debug.LogWarning("Couldn't initialize Steam");
            return;
        }

        Debug.Log("Steam Initialized: " + client.Username + " / " + client.SteamId);
    }

    void Update()
    {
        if (client == null)
            return;

        try
        {
            UnityEngine.Profiling.Profiler.BeginSample("Steam Update");
            client.Update();
        }
        finally
        {
            UnityEngine.Profiling.Profiler.EndSample();
        }
    }

    private void OnDestroy()
    {
        if (client != null)
        {
            client.Dispose();
            client = null;
        }
    }
}
