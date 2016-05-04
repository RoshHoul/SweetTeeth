using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "Player")
        {

            Application.LoadLevel("Game Over");
        } else if ((other.transform.tag == "Candy") || (other.transform.tag == "Tooth"))
        {
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

}
