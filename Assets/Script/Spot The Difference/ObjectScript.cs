using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public LogicManager logic;

    private void OnMouseDown()
    {
        if (!logic.isWon)
        {
            logic.clickDetected();
            logic.spawnMarker(transform.position, transform.rotation);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
