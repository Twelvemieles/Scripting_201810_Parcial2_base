using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mananger : MonoBehaviour
{
    public Text ScoreText;
    private int score;
    private GameObject gameOverText;
    [SerializeField]
    private Transform[] lugaresRes;
    [SerializeField]
    private Rigidbody[] enemies;
    
    // Use this for initialization
    void Start()
    {
        StartCoroutine(respawnearEnemies());
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SumarPuntaje(int value)
    {

        score += value;
        UpdateScore();


    }
    void UpdateScore()
    {
        ScoreText.text = "score:" + score;
    }

    public void GameOver() //esto hace aparecer el menú de ganar
    {
        gameOverText.SetActive(true);

    }
    private IEnumerator respawnearEnemies()
    {
        int i = Random.Range(0, lugaresRes.Length);
        int e = Random.Range(0, enemies.Length);
        Rigidbody bulletInstance = Instantiate(enemies[i], lugaresRes[e].position , transform.rotation);
        
        yield return new WaitForSeconds(4F);
        
    }
}
