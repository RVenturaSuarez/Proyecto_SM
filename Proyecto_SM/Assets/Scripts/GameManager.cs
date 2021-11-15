using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Lvl1Controller lvl1Controller;
    public static GameManager instance;
    private PlayerController playerC;
    public int currentStateLevel;
    public int valueNpcID;
    private Logic_Extintor extintor;


    private GameObject interactableObject;
    public static Logic_Extintor extLogi;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            extLogi = FindObjectOfType<Logic_Extintor>();
        }
        else
        {
            Destroy(gameObject);
        }   
    }


    private void Start()
    {


    }

    private void Update()
    {

        if (currentStateLevel == 1 && lvl1Controller == null )
        {
            lvl1Controller = GameObject.FindGameObjectWithTag("Level_1_Controller").GetComponent<Lvl1Controller>();
            playerC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }



        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeLevel(1);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeLevel(0);
        }
    }

    private void ChangeLevel( int levelID)
    {
        currentStateLevel = levelID;
        SceneManager.LoadScene(levelID);
    }

    public void Interact()
    {
        if (currentStateLevel == 0)
        {
            // Activar dialogo con NPC's
            ActivateDialog(valueNpcID);
        }
        else if (currentStateLevel == 1)
        {

            interactableObject = playerC.GetInteractableObject();
            extintor = lvl1Controller.getExtintorInGame().GetComponent<Logic_Extintor>();
            Debug.Log("Estoy Pulsando");
            // Activar extintor
            if (extintor._parent == null)
            {
                Debug.Log("No puedes apagar el fuego así");
            } else
            {
                extintor.ExtinguirFuego(interactableObject);
            }
        } 
        else if (currentStateLevel == 2)
        {
            // ????
        } 
        else if (currentStateLevel == 3)
        {
            // Disparar
        }
    }



    public void ActivateDialog(int npcID)
    {
        // Lógica para activar dialogos
    }

}
