using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

    public void Play(string play)
    {
        Application.LoadLevel(play);
    }

    public void Exit()
    {
        if (Application.isEditor)
            Debug.Log("Attempted to quit from the Editor.");
        else if (Application.isWebPlayer)
            Debug.Log("Attempted to quit from the Web Player.");
        else
            Application.Quit();
    }

    public void Replay(string replay)
    {
        Application.LoadLevel(replay);
    }
}
