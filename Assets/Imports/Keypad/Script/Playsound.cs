using UnityEngine;


public class Playsound : MonoBehaviour 
{
	public void PlaySound()
	{
		GetComponent<AudioSource>().Play();
	}

}
