using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private PlayerController playerC;
    public int currentStateLevel;
    public int valueNpcID;


    private GameObject interactableObject;
    public static Logic_Extintor extLogi;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            currentStateLevel = 1;
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
        playerC =  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); 
    }

    private void Update()
    {
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
            var extintor = Lvl1Controller.instance.extintorInGame.GetComponent<Logic_Extintor>();

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

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentStateLevel);
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
}
