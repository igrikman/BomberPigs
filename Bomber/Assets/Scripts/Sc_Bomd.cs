using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Bomd : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private bool boom = false;
    private void Start()
    {
        BomdDestroi();
    }
    private void BomdDestroi()
    {
        boom = true;
        Invoke("Exposion", 3f);
        Destroy(gameObject, 3f);
    }
    private void Exposion()
    {
        if (boom == true)
        {
            Debug.Log("Взрыв");
            Instantiate(explosionPrefab, gameObject.transform.position, new Quaternion());
            boom = false;
        }
        else
        {
            Debug.Log("Взрыв нет");
        }
    }
}