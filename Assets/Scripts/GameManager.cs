using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance { get; private set; }

    public PlayerBehaviour Player {get ; private set;}
    /* public PlayerBehaviour GetPlayer() // Player { get; }
    {
        return Player;
    } */
    

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        
        Player = FindAnyObjectByType<PlayerBehaviour>();
        if (Player == null)
            Debug.LogError("No Player found");
        else
            Debug.Log("Found Player");
    }
    
}
