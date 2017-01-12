﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stats : MonoBehaviour
{

    // Use this for initialization
    private int _badHombreSpawnCount;
    private int _cameraManSpawnCount;

    private int _badHombreKillCount;
    private int _cameraManKillCount;

    public IList<GameObject> Hearts;
    public GameObject ScriptController;
    public float time;

    void Start ()
    {
        Hearts = new GameObject[5];

        _badHombreSpawnCount = 0;
        _cameraManSpawnCount = 0;
        _badHombreKillCount = 0;
        _cameraManKillCount = 0;

        time = 0;
        ScriptController = GameObject.Find("ScriptController");

        Vector2 heartPosition = new Vector2(-6, 8);
        for (int i = 0; i < 5; i++)
        {
            Hearts[i] = Instantiate(Resources.Load("FullHeart")) as GameObject;
            Hearts[i].name = "FullHeart" + (i + 1);
            Hearts[i].transform.position = heartPosition;
            heartPosition.x += 1.5F;
        }


    }

    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time + " time");
    }

    public void RemoveHeart(int Lives)
    {
        GameObject heart = Hearts[Lives];
        Vector2 heartPosition = new Vector2(heart.transform.position.x, heart.transform.position.y);

        GameObject.Destroy(heart);
        heart = GameObject.Instantiate(Resources.Load("EmptyHeart")) as GameObject;
        heart.name = "EmptyHeart" + Lives;
        heart.transform.position = heartPosition;
    }

    public void BadHombreKilled()
    {
        _badHombreKillCount++;
        ScriptController.GetComponent<ScoreController>().UpdateScore(500);
    }
    public void BadHombreSpawned()
    {
        _badHombreSpawnCount++;
    }
    public void CameraManKilled()
    {
        _cameraManKillCount++;
        ScriptController.GetComponent<ScoreController>().UpdateScore(300);

    }
    public void CameraManSpawned()
    {
        _cameraManSpawnCount++;
    }

    public int BadHombreSpawnCount
    {
        get
        {
            return _badHombreSpawnCount;
        }
    }
    public int BadHombreKillCount
    {
        get
        {
            return _badHombreKillCount;
        }
    }
    public int CameraManSpawnCount
    {
        get
        {
            return _cameraManSpawnCount;
        }
    }
    public int CameraManKillCount
    {
        get
        {
            return _cameraManKillCount;
        }
    }
}
