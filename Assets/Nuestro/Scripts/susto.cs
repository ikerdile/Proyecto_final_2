using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class susto : MonoBehaviour {
	public Texture Image;
	public AudioClip Sound;
	public float timeShow = 1.5F;
	bool show;
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.name == "ZoneScream")
		{
			show = true;
		}
	}
	
	void OnGUI()
	{
		if(show)
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Image);
			AudioSource.PlayClipAtPoint(Sound, transform.position);
			StartCoroutine("OFF");
		}
	}
	
	IEnumerator OFF()
	{
		yield return new WaitForSeconds(timeShow);
		show = false;
	}
}