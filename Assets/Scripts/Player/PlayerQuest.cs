using UnityEngine;
using System.Collections;
using System.Collections.Generic;


class PlayerQuest : MonoBehaviour
{
    public List<string> inventory;
    public bool Quest;
    private Rigidbody PlayerRigidbody;

    void Start()
    {
        //PlayerRigidbody = gameObject.AddComponent<Rigidbody>();

        Quest = false;
        inventory = new List<string>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Marteau")
        {
            inventory.Add("Marteau");
            collision.gameObject.SetActive(false);
        }
    }
}