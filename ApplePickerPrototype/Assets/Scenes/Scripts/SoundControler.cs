using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour
{
	public GameObject soundOn;
	public GameObject soundOff;
	void Awake()
	{
		soundOn = GameObject.Find("SoundOn");
		soundOff = GameObject.Find("SoundOff");

		if (PlayerPrefs.GetInt("Mute", 0) == 1)
		{
			AudioListener.volume = 0;
			soundOn.SetActive(false);
			soundOff.SetActive(true);
		}
		else
		{
			AudioListener.volume = 1;
			soundOn.SetActive(true);
			soundOff.SetActive(false);
		}
	}
	public void Sound()
    {
		if (PlayerPrefs.GetInt("Mute", 0) == 0)
		{
			AudioListener.volume = 0;
			PlayerPrefs.SetInt("Mute", 1);
			soundOn.SetActive(false);
			soundOff.SetActive(true);

		}
		else
		{
			AudioListener.volume = 1;
			PlayerPrefs.SetInt("Mute", 0);
			soundOn.SetActive(true);
			soundOff.SetActive(false);

		}

		PlayerPrefs.Save();
	}

}
