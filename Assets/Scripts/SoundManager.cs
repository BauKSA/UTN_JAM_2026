using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource efectos;

    public AudioClip ak47;
    public AudioClip apilarBloques;
    public AudioClip criaturas;

    void Awake()
    {
        Instance = this;
    }

    public void Play(AudioClip clip)
    {
        if (clip != null)
            efectos.PlayOneShot(clip);
    }
}