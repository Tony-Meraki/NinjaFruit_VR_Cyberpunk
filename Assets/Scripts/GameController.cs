using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject[] fruitPrefabs;

    public Slicer player;
    public TMP_Text infoText;

    public float horizontalArea = 5f;
    public float spawnDuration = 3f;

    //?
    public float spawnHeight = 0.5f;
    public float spawnDepth = -3f;

    public float gameTimer = 15f;

    private float spawnTimer;
    private float resetTimer = 3f;

    [SerializeField] private AudioClip _clip;
    void Start()
    {
        spawnTimer = spawnDuration;
        SoundManager.Instance.PlayBackGroundSound(_clip);
    }

    void Update()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0f)
            {
                spawnTimer = spawnDuration;

                for (int i = 0; i < 3; i++)
                {
                    GameObject friut = Instantiate(fruitPrefabs[Random.Range(0, fruitPrefabs.Length)]);
                    //friut.transform.localRotation = new Vector3(0, 90, 0);
                    friut.transform.position = new Vector3(
                        horizontalArea,
                        //Random.Range(-horizontalArea, horizontalArea),
                        spawnHeight,
                        spawnDepth
                    );
                }
            }

            infoText.text = "Ninja Fruits\nTime : " + Mathf.Floor(gameTimer) + "\nScore: " + player.score;
        }
        else
        {
            infoText.text = "Game Over\nScore: " + player.score + "\nRetry";
            SoundManager.Instance.StopBackGroundSound(_clip);

            //끝난 뒤 자동으로 몇초 지나면 재실행될 수 있도록 //필요없음
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

}
