﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour { 

 public static GM instance = null;

public float yMinLive = -10f;
public Transform spawnPoint;
public GameObject playerPrefab;


PlayerCtrl player;

public float TimeToRespawn = 2f;

 	void Awake(){
		 if(instance == null) {
			 instance = this;
		 }
		
	 }

 	void Start () {
		 if (player == null) {
			 RespawnPlayer();
		 }
		
	}
	
	void Update () {
		if(player == null) {
			GameObject obj = GameObject.FindGameObjectWithTag("Player");
			if (obj != null) {
				player = obj.GetComponent<PlayerCtrl>();
			}
		}
		
	}
	public void RespawnPlayer() {
	 Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}
	public void KillPlayer(){
		if(player != null) {
			Destroy(player.gameObject);
			Invoke("RespawnPlayer", TimeToRespawn);
		}

	}
}
