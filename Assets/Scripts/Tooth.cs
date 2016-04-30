using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooth : MonoBehaviour {

    public int index;
    public float timer;
    Vector3 pos;
    int state = 1;



    public Tooth( int _index, float _timer )
    {
        index = _index;
        timer = _timer;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//        State();
        
        if (FindChild())
        {
            if (state == 1)
            {
                timer = 50f;
                //TODO: Start Timer
                timer = timer - Time.deltaTime;
                Debug.Log(timer);
                if (timer <= 0)
                {
                    this.GetComponent<Rigidbody2D>().isKinematic = false;
                }

            }
        }
    }

    void State()
    {

        
        //TODO: fix names
        if (this.GetComponent<SpriteRenderer>().sprite == Resources.Load("Assets/Sprites/normal.png")) {
            timer = 5f;
        }/* else if (this.GetComponent<Image>().sprite == Resources.Load("LightYellow"))
        {
            timer = 4f;
        }
        else if (this.GetComponent<Image>().sprite == Resources.Load("DarkYellow"))
        {
            timer = 2f;
        }
        else if (this.GetComponent<Image>().sprite == Resources.Load("Brown"))
        {
            timer = 1.5f;
        } */
    }

    public bool FindChild()
    {
        if (this.transform.childCount > 0)
        {
            return true;
        }
        else {
            return false;
        }
    }

  /*  void Timer()
    {
        if (FindChild())
        {
            State();
            //TODO: Start Timer
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                this.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }*/

}
