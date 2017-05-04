using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioClip _soundName;
    private float _AudioVolume;
    private bool _PlaySong;
    private bool _isSongPlaying;
    private bool _isSongLooping;

	void Start () {
        this.gameObject.AddComponent<AudioSource>();
    }
	
	void Update () {

        if (_PlaySong == true && _isSongPlaying == false)
        {
            this.gameObject.GetComponent<AudioSource>().clip = _soundName;
            
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(_soundName, _AudioVolume);

            if (_isSongLooping == true)
            {
                this.gameObject.GetComponent<AudioSource>().loop = true;
            }
            else
            {
                this.gameObject.GetComponent<AudioSource>().loop = false;
            }

            _isSongPlaying = true;
        }
        else if (_PlaySong == false && _isSongPlaying == true)
        {
            _isSongPlaying = false;
        }
    }

    public void PlaySong(AudioClip SoundTrackName, float SoundVolume, bool IsSongLooping)
    {
        _soundName = SoundTrackName;
        _AudioVolume = SoundVolume;
        _isSongLooping = IsSongLooping;
    }

    public bool GetSongOnOff
    {
        get { return _PlaySong; }
        set { _PlaySong = value; }
    }


}
