using UnityEngine;
using System.Collections;


//Make the camera work
public class RC_SkyBoxController : MonoBehaviour {

	public GameObject player;
	//Object Offset
	private Vector3 offset;

	private GameObject dirLight;

	//Day Night Stuff
	Renderer rend;
	public float scrollSpeed = 0.5f;




	void Start () {
		//Offset it to the player
		offset = transform.position - player.transform.position;

		//Grab the renderer
		rend = GetComponent<Renderer>();
		dirLight = GameObject.Find("DirLight");
		
	}

	private void Update() {
		//Day night cycle
		float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
		dirLight.transform.Rotate (0,scrollSpeed,0);
	}

	

	void LateUpdate () {
		//Let it follow the player
		transform.position = player.transform.position + offset;
	}
}
