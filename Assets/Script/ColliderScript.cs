using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    /*private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "")
        {
            Debug.Log("collision");
            Destroy(col.gameObject);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            GameManager.instance.GameOver = true;
            Time.timeScale = 0;
        }
    }
}
