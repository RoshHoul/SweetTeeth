using UnityEngine;
using System.Collections;

public class CandyDestroy : MonoBehaviour {

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
