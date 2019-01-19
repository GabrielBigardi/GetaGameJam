using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public enum Item { Machado, Chave, Madeira, Pocao1, Pocao2, Pocao3 }
    public Item curItem;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            switch (curItem)
            {

                case Item.Machado:
                    PlayerController.Instance.GiveItem(0);
                    break;

                case Item.Chave:
                    PlayerController.Instance.GiveItem(1);
                    break;

                case Item.Madeira:
                    PlayerController.Instance.GiveItem(2);
                    break;

                case Item.Pocao1:
                    PlayerController.Instance.GiveItem(3);
                    break;

                case Item.Pocao2:
                    PlayerController.Instance.GiveItem(4);
                    break;

                case Item.Pocao3:
                    PlayerController.Instance.GiveItem(5);
                    break;

                default:
                    print("ERRO DESCONHECIDO");
                    break;
            }
            
            Destroy(this.gameObject);
        }
    }
}
