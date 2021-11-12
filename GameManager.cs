using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoardManager boardscript;

    private void Awake()
    {
        boardscript = GetComponent<BoardManager>();


    }
    private void Start()
    {
        InitGame();


    }

    void InitGame()
    {
        boardscript.SetupScene();
    }
}
