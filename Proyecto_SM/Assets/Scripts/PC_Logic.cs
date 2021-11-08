using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Logic : MonoBehaviour
{
    private bool onFire;
    public Material _PCMaterial;
    public Material _FireMaterial;
   
    [SerializeField]private int fireProb;
    private int randomNum;

    // Start is called before the first frame update
    void Start()
    {
        onFire = false;
        InvokeRepeating("GenerateFire", 0f, 3f);
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
            Lvl1Controller.instance.IncrementPCCounter();
        }
    }

    public void Apagar()
    {
        onFire = false;
        Lvl1Controller.instance.DisminuirPCCounter();
        CancelInvoke("GenerateFire");
        StartCoroutine("WaitForMe");
    }

    IEnumerator WaitForMe()
    {
        yield return new WaitForSeconds(3);
        InvokeRepeating("GenerateFire", 0f, 3f);
    }
}
