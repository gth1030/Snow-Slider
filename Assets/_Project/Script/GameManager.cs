using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public float m_startDelay = 3f;
    public float m_endDelay = 3f;
    [HideInInspector]public PlayerManager player;
    public GameObject playerPrefeb;
    public Transform spawnPoint;
    public CameraController m_cameraControll;
    public Text restartText;
    public GameObject barrelSpawn;

    private WaitForSeconds m_startWait;
    private WaitForSeconds m_endWait;
    private bool game;
    private bool restart;
    private SpawnBarrel spawnBarrels;


    public void InitializeGame()
    {
        m_startWait = new WaitForSeconds(m_startDelay);
        m_endWait = new WaitForSeconds(m_endDelay);
        createPlayer();
        m_cameraControll.SetupCamera();
        restart = false;
        if (barrelSpawn != null)
        {
            spawnBarrels = barrelSpawn.GetComponent<SpawnBarrel>();
        }

        StartCoroutine(gameLoop());

    }

    void Start () {
        restartText.text = "";

    }
    

    IEnumerator gameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());
    }



    IEnumerator RoundStarting()
    {
        restartText.text = "";
        game = true;
        player.instance.transform.position = spawnPoint.transform.position;
        player.instance.transform.rotation = spawnPoint.transform.rotation;
        player.ReSet();
        if (spawnBarrels != null)
        {
            spawnBarrels.activateBarrel();
        }
        yield return m_startWait;
    }

    IEnumerator RoundPlaying()
    {


        while (player.instance.GetComponent<PlayerHealth>().isAlive())
        {
            yield return null;
        }
        if (spawnBarrels != null)
        {
            spawnBarrels.deactivateBarrel();
        }
        player.instance.GetComponent<PlayerHealth>().onDeath();
        restart = true;
    }

    IEnumerator RoundEnding()
    {
        restartText.text = "Press 'R' to restart";
        yield return m_endWait;
        game = false;
    }
	

	void Update () {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                restart = false;
                StartCoroutine(gameLoop());
            }
        }
    }


    void createPlayer()
    {
        player.instance = Instantiate(playerPrefeb, spawnPoint.position, spawnPoint.rotation) as GameObject;
        player.SetUp();
        m_cameraControll.target = player.instance;
        GetComponent<PauseManager>().player = player.instance;
    }

}
