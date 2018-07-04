using UnityEngine;
using System.Collections;

public class themeSongContinuous : MonoBehaviour
{
    private static themeSongContinuous instance = null;
    public static themeSongContinuous Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Application.loadedLevel == 5 || Application.loadedLevel == 2 || Application.loadedLevel == 7 || 
            Application.loadedLevel == 6 || Application.loadedLevel == 4 || Application.loadedLevel == 3)
            this.GetComponent<AudioSource>().Pause();
        else
            this.GetComponent<AudioSource>().UnPause();
    }
}
