using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    //   public GameObject platform
    public Tooth tooth;
//    public GameObject toothTest;
    public GameObject candy;
    public float timer = 10f;
    List <Tooth> platform = new List<Tooth>();
    int prev = 0;


    // Use this for initialization
    void Start()
    {
        SetUpScene();
        InvokeRepeating("SpawnCandy", 2, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < platform.Count; i++)
        {
            if (platform[i].transform.childCount > 0)
            {
                /*  timer -= Time.deltaTime;
                  //                Debug.Log("vreme: " + timer);
                  if (timer < 0)
                  {
                      platform[i].GetComponent<Rigidbody2D>().isKinematic = false;
                      timer = 5f;
                  }
                  */
                
                platform[i].GetComponent<Tooth>().CallTimer();
            }

        } 
    }

    void SetUpScene()
    {
        for (int i = -7; i < -2; i++)   // RIGHT ONE: int i = -7; i < -2; i++
        {
            Tooth thisObject = Instantiate(tooth, new Vector3(i * 0.8f, -2, 0), Quaternion.identity) as Tooth;
            platform.Add(thisObject);
   
        }

        for (int i = 3; i < 8; i++)
        {
            Tooth thisObject = Instantiate(tooth, new Vector3(i * 0.8f, 2, 0), Quaternion.identity) as Tooth;
            platform.Add(thisObject);
        }

        for (int i = -1; i < 2; i++)
        {
            Tooth thisObject = Instantiate(tooth, new Vector3(i * 0.8f, 0, 0), Quaternion.identity) as Tooth;
            platform.Add(thisObject);
        }
        
    /*    for (int i = 7; i < 10; i++)
        {
            GameObject thisObject = Instantiate(tooth, new Vector3(i * 0.8f, -3.78f, 0), Quaternion.identity) as GameObject;
            platform.Add(thisObject);
        }
        */

    }

    void SpawnCandy()
    {
        int rand = Random.Range(0, platform.Count);
        
        if (prev == rand)
        {
            if (rand != platform.Count)
            {
                rand++;
            }
            else
            {
                rand--;
            }
        }
        Vector3 candyPos = platform[rand].transform.position;
        candyPos.y = platform[rand].transform.position.y + 0.8f;
        GameObject currCandy = Instantiate(candy, candyPos, Quaternion.identity) as GameObject;
        currCandy.transform.parent = platform[rand].transform;
        prev = rand;
    } 


}



/* PSEUDO CODE
    i = rand between 1 20

    instantiate = (platformp[i], 
    */