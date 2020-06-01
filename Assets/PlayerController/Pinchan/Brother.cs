﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brother : MonoBehaviour
{
    Transform player;
    public float radius;
    bool Open;
    public GameObject Store;
    FollowPlayer CameraController;
    public PlayerController Player;
    public GameObject CloseText;
    public GameObject ExclamationSign;
    
    void Awake(){
        Store = GameObject.Find("Shop");
        CloseText = GameObject.Find("CloseText");
        Player = GameObject.FindObjectOfType<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        CameraController = GameObject.FindObjectOfType<FollowPlayer>();
         Store.SetActive(false);
    }
    void Start()
    {
        CloseText.SetActive(false);
        ExclamationSign.SetActive(false);
        gameObject.SetActive(false);
        EnemiesController.main.OnWaveBegins += OnWaveBegins;
    }

    
    void Update()
    {
        if(Vector3.Distance(transform.position , player.position )  < radius ){
            ExclamationSign.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)){
                Open = !Open;
                OpenStore(Open); 
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter)){
                
            }
        }
    }
    void OpenStore( bool Open ){
        Cursor.visible = Open;
        if(Open){
            CameraController.Offset += Vector3.up * 15;
            //Cursor.lockState = CursorLockMode.None;
        }else{ 
            CameraController.Offset -= Vector3.up * 15;
            //Cursor.lockState = CursorLockMode.Locked;
        }
        Store.SetActive(Open);
        CloseText.SetActive(Open);
        ExclamationSign.SetActive(!Open);
        Player.enabled = !Open;
       
    }

    void OnWaveBegins(){
        if (Open){
            Open = false;
            OpenStore(false);
        }
    }
}
