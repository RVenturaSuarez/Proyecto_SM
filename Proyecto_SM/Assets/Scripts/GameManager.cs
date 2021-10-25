using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int currentStateLevel;
    public int valueNpcID;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            currentStateLevel = 0;
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }   
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
        } else if (currentStateLevel == 1)
        {
            // Activar extintor
            

        } else if (currentStateLevel == 2)
        {
            // ????
        } else if (currentStateLevel == 3)
        {
            // Disparar
        }
    }



    public void ActivateDialog(int npcID)
    {
        // Lógica para activar dialogos
    }
}
