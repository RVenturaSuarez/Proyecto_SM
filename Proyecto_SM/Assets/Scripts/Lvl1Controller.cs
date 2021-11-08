using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl1Controller : MonoBehaviour
{
    public static Lvl1Controller instance = null;
    private PlayerController playerC;
    [SerializeField] private GameObject extintorPrefab;
    public GameObject extintorInGame;
    [SerializeField] private GameObject extSpawn;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;
    public float timer;
    public float timeToWIN = 30;
    public Text timeText;
    public int pcBadCount;
    public int limitBadPCs = 5;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        timer = timeToWIN;
        playerC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        InstantiateExt();

    }

    // Update is called once per frame
    void Update()
    {

        if(timer <= 0.0f)
        {
            // Lógica WIN
            Time.timeScale = 0;
            timeText.text = "You Win!";
            WinPanel.SetActive(true);
            Debug.Log("YOU WIN");
        } else
        {
            timer -= Time.deltaTime;
            timeText.text = "" + ((int)timer);
            Debug.Log((int)timer);
        }


    }

    IEnumerator CreateExtintorInGame()
    {
        Instantiate(extintorPrefab, extSpawn.transform.position, extSpawn.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        extintorInGame = GameObject.FindGameObjectWithTag("Extintor");
    }

 


    public void InstantiateExt()
    {

        StartCoroutine(CreateExtintorInGame());

    }

    public void IncrementPCCounter()
    {
        pcBadCount++;
        if(pcBadCount >= limitBadPCs)
        {
            Time.timeScale = 0;
            LosePanel.SetActive(true);
            Debug.Log("Lose");
        }
    }

    public void DisminuirPCCounter()
    {
        pcBadCount--;
    }
}
