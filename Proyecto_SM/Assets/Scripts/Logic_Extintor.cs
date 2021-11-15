using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic_Extintor : MonoBehaviour
{

    private Lvl1Controller lvl1Controller;
    private int uses = 3;
    public GameObject _parent;

    // Start is called before the first frame update
    void Start()
    {
        lvl1Controller = GameObject.FindGameObjectWithTag("Level_1_Controller").GetComponent<Lvl1Controller>();
        _parent = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _parent = other.gameObject;
        }
    }

    public void ExtinguirFuego(GameObject pc)
    {
        if(uses > 0)
        {
            pc.GetComponent<PC_Logic>().Apagar();
            uses--;

            if(uses <= 0)
            {
                Destroy(gameObject);
                // Spawn new extintor in game
                lvl1Controller.InstantiateExt();
            }
        }
        
    }
        
}
