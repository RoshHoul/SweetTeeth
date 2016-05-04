using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

    public void Play(string play)
    {
        Application.LoadLevel(play);
    }
}
