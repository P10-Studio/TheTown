using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayOneShot(EventReference clip, Vector3 position)
    {        
        if (clip.IsNull)
        {
            Debug.LogWarning("Attempted to play a null audio clip.");
            return;
        }

        RuntimeManager.PlayOneShot(clip, position);
    }

    public void PlayTypingSound()
    {
        var instance = RuntimeManager.CreateInstance(FMODEvents.Instance.TextTypingSound);
        var pitch = Random.Range(0f, 1f);
        instance.setParameterByName("DialogueTypingPitch", pitch);
        instance.start();
        instance.release();
    }
}