using UnityEngine;
using System.Collections;

public class CandyDestroy : MonoBehaviour {
	void OnCollisionEnter2D (Collision2D col)
	{
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
