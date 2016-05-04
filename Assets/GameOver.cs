using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "Player")
        {

            Application.LoadLevel("Game Over");
        }
    }

}
