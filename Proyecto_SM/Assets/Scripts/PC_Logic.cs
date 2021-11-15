using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Logic : MonoBehaviour
{
    private Lvl1Controller lvl1Controller;
    private bool onFire;
    public Material _PCMaterial;
    public Material _FireMaterial;
   
    [SerializeField]private int fireProb;
    private int randomNum;

    // Start is called before the first frame update
    void Start()
    {
        lvl1Controller = GameObject.FindGameObjectWithTag("Level_1_Controller").GetComponent<Lvl1Controller>();
        onFire = false;
        InvokeRepeating("GenerateFire", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (onFire)
        {
            GetComponent<MeshRenderer>().material = _FireMaterial;
        }
        else
        {
            GetComponent<MeshRenderer>().material = _PCMaterial;
        }
    }

    private void GenerateFire()
    {
        randomNum = Random.Range(0, 101);

        //Debug.Log("Soy: " + gameObject.name + " y mi numero es: " + randomNum);

        if (randomNum >= fireProb)
        {
            onFire = true;
            lvl1Controller.IncrementPCCounter();
        }
    }

    public void Apagar()
    {
        onFire = false;
        lvl1Controller.DisminuirPCCounter();
        CancelInvoke("GenerateFire");
        StartCoroutine(WaitForMe());
    }

    IEnumerator WaitForMe()
    {
        yield return new WaitForSeconds(5);
        InvokeRepeating("GenerateFire", 0f, 5f);
    }
}
