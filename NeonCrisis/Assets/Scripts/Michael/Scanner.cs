using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scanner : MonoBehaviour {

	[SerializeField]
	private Image scannerImage;

	private float rot;

	[SerializeField]
	private RectTransform rect;

	[SerializeField]
	private Sprite boss;

	// Use this for initialization
	void Start () {
		GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		rect.rotation = Quaternion.Lerp (rect.rotation, Quaternion.Euler (new Vector3 (0, 0, rot)), Time.deltaTime * 2);

		if (GameObject.Find ("Boss(Clone)")) 
		{
			scannerImage.sprite = boss;
			scannerImage.material = null;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.GetComponent<Moving_Spawner> ()) 
		{
			scannerImage.sprite = coll.gameObject.GetComponent<Moving_Spawner> ().enemy_to_spawn.GetComponent<SpriteRenderer> ().sprite;
			scannerImage.material = coll.gameObject.GetComponent<Moving_Spawner> ().enemy_to_spawn.GetComponent<SpriteRenderer> ().sharedMaterial;
			//scannerImage.sprite = coll.gameObject.GetComponent<SpriteRenderer> ().sprite;
			//scannerImage.material = coll.gameObject.GetComponent<SpriteRenderer> ().material;
			rot += 90;
		}

	}



}
