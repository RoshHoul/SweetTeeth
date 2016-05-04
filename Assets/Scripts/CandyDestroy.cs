using UnityEngine;
using System.Collections;

public class CandyDestroy : MonoBehaviour {


	Animator animator;
	void OnCollisionEnter2D (Collision2D col)
	{
		animator = GetComponent<Animator> ();
		if(col.gameObject.tag == "Candy")
		{
            Debug.Log("Colliding with: " + col.gameObject.name);
            //col.gameObject.SetActive(false);
            GameObject testObj = col.gameObject;
            testObj.transform.parent = null;
            Destroy(testObj);
		}
	}
}
