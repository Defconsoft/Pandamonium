﻿using UnityEngine;
using System.Collections;


//Make the camera work
public class RC_CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	void Start () {
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
