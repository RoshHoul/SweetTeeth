using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    Animator anim;
    bool fadeOut = false;
    public float timeLeft = 0f;
    LoadingScreen temp;
	// Update is called once per frame

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("panel").GetComponent<Animator>();
    }

	void Update () {

        timeLeft += Time.deltaTime;
        if (timeLeft >= 3)
            anim.SetTrigger("fadeOut");
        
        if (timeLeft >= 4.5f)
        {
            
            //            StartCoroutine(LevelLoad());
            Application.LoadLevel("Main Menu");
        }
	}

    //load level after one sceond delay
    IEnumerator LevelLoad()
    {
        yield return new WaitForSeconds(1f);
        Application.LoadLevel("Main Menu");
    }
}
