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

    private WaitForSeconds m_startWait;
    private WaitForSeconds m_endWait;
    private bool game;
    private bool restart;


	void Start () {
        m_startWait = new WaitForSeconds(m_startDelay);
        m_endWait = new WaitForSeconds(m_endDelay);
        createPlayer();
        m_cameraControll.SetupCamera();
        restart = false;

        StartCoroutine(gameLoop());
	
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
        yield return m_startWait;
    }

    IEnumerator RoundPlaying()
    {


        while (player.m_terrainTracker.playerAlive)
        {
            yield return null;
        }
        player.instance.gameObject.SetActive(false);
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
    }

}
