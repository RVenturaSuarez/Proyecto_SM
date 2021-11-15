using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private Lvl2Controller lvl2Controller;

    private void Start()
    {
        lvl2Controller = FindObjectOfType<Lvl2Controller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lvl2Controller.GetPoints();
            Destroy(gameObject);
        }
    }
}
