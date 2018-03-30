using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour {

	public static AudioCtrl instance;
    public AudioFX audioFX;
    public float zombieAudioDelayMin;
    public float zombieAudioDelayMax;

    private float lastZombieAudioFX;
    private float randomZombieAudioDelay;

    void Awake () {
		if(instance == null)
        {
            instance = this;
        }
	}

    void Start()
    {
        lastZombieAudioFX = Time.time;
        randomZombieAudioDelay = zombieAudioDelayMin;
    }


    void Update () {
        PlayZombieAudio();
    }

    void PlayZombieAudio()
    {
        if(lastZombieAudioFX + randomZombieAudioDelay < Time.time )
        {
            lastZombieAudioFX = Time.time;
            if(Random.value > 0.5f)
            {
                PlayerZombie1();
            }
            else
            {
                PlayerZombie2();
            }
            randomZombieAudioDelay = Random.Range(zombieAudioDelayMin, zombieAudioDelayMax);

        }
    }

    public void PlayerShoot()
    {
        AudioSource.PlayClipAtPoint(audioFX.playerShoot, Vector3.zero);
    }

    public void PlayerZombie1()
    {
        AudioSource.PlayClipAtPoint(audioFX.zombie1, Vector3.zero);
    }

    public void PlayerZombie2()
    {
        AudioSource.PlayClipAtPoint(audioFX.zombie2, Vector3.zero);
    }
}
