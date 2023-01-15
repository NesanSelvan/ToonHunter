using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemiesalive = 0;
    public int round = 0;
    public int currentround = 0;
    public GameObject[] Toons;
    public GameObject[] SpawnPoints;
    public GameObject enemyprefab;
    public Text roundNumber;
    public GameObject endscreen;
    float delayTimer = 4;
float timer;
public RadialCountdown countdown;
    Vector3 randomPosition;
    // Start is called before the first frame update
    void Start()
    {
       countdown = countdown.GetComponent<RadialCountdown>();
        //for (int i = 0; i < SpawnPoints.Length; i++)
        //{
        //    SpawnPoints[i] = transform.GetChild(i).gameObject;
        //}
    }

    // Update is called once per frame
    void Update()
    {
Debug.Log("Countdown" + countdown.seconds);
       if(enemiesalive <= 10){
        NextWave();
       }
        
        
     
    }
    
    private void  NextWave()
    {
                 randomPosition = new Vector3(
        Random.Range(-20, 35),3.8f,
        Random.Range(0, -43.1f)
    ); 
    for(int i = 0;i<=10;i++)
        {
      timer += Time.deltaTime; 
        if (timer >= delayTimer) {
 
            GameObject spawnToons = Toons[Random.Range(0,Toons.Length)];
            GameObject spawnpoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];

            // GameObject enemyspawned = Instantiate(spawnToons, spawnpoint.transform.position, Quaternion.identity);
            GameObject enemyspawned = Instantiate(spawnToons,randomPosition, Quaternion.identity);

            enemyspawned.GetComponent<ToonController>().m_gamemanager = GetComponent<GameManager>();
            Debug.Log("Enemies"+ enemiesalive);
            enemiesalive++;
            timer = 0;
        }
        }
    }
   
    
}

