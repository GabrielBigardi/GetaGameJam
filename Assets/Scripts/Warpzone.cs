using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warpzone : MonoBehaviour {

	public Transform warpPos;
    public Vector3 offset;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerController.Instance.StartCoroutine(PlayerController.Instance.Teleport_CR(warpPos.position.x + offset.x, warpPos.position.y + offset.y, warpPos.position.z + offset.z));
        }
    }
}
