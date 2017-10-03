using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;

public struct Room
{
    private string name;
    public string Name{get{return this.name;}}

    private int currentSize;
    public int Size{get{return currentSize;}}

    private NetworkID id;
    public NetworkID ID{get{return id;}}

    public Room(string name, NetworkID id, int size)
    {
        this.id = id;
        this.name = name;
        this.currentSize = size;
    }
};

public class ListMatches : MonoBehaviour 
{
    public Action<List<Room>> OnMatchFound;

    private int amountOfRooms;
    public int AmountOfRooms{get{return amountOfRooms;}}

    private void Start()
    {
        NetworkManager.singleton.StartMatchMaker();
        this.listMatches();
    }

    public void listMatches()
    {
        NetworkManager.singleton.matchMaker.ListMatches(0, 10, "", true, 0, 0, onMatchList);
    }

    private void onMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        if (!success)
            return;
        
        amountOfRooms = 0;
        List<Room> rooms = new List<Room>();
        for (var i = 0; i < matches.Count; i++)
        {
            rooms.Add(new Room(matches[i].name, matches[i].networkId, matches[i].currentSize));
            amountOfRooms++;
        }

        if (OnMatchFound != null)
            OnMatchFound(rooms);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
            this.listMatches();
    }
}
