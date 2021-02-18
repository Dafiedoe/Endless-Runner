using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public enum SoundType
    {
        Shooting,
        Hit,
        Kill
    }

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip shootSound, hitSound, enemyDiesSound;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        transform.position = Camera.main.transform.position;
    }

    public void PlaySound(SoundType type)
    {
        switch (type)
        {
            case SoundType.Shooting:
                source.clip = shootSound;
                break;
            case SoundType.Hit:
                source.clip = hitSound;
                break;
            case SoundType.Kill:
                source.clip = enemyDiesSound;
                break;
        }
        source.Play();
    }
}
