using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndo : MonoBehaviour
{

    public Transform spawnPos;
    public Transform incomingPrefab;

    public void InstantiateMonster()
    {
        Instantiate(incomingPrefab, spawnPos.position, Quaternion.identity);
    }

    public void HidePlayer()
    {
        PlayerController.Instance.transform.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
