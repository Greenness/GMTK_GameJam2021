using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    
    ObjectPooler bulletPooler;
    public GameObject bulletPrefab;
    public TextMeshProUGUI GameOverText, StartScreenText, StartScreenSubText, PauseScreen, HealthText, LevelText;
    public GameObject BoneSprite;
    public GameObject StartScreenBackdrop;

    public GameObject player;

    private bool clickToStart = true;
    private bool isGameOver = false;
    private bool isGamePaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        bulletPooler = new ObjectPooler(bulletPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (clickToStart && Input.GetButtonDown("Jump")) {
            hideStartScreen();
        } else if (isGameOver && Input.GetButtonDown("Jump")) {
            ResetGame();
        } else if (Input.GetButtonDown("Jump")) {
            isGamePaused = !isGamePaused;
            PauseGame();
        }
    }

    public void setHealthText(float health) {
        if (health >= 0) {
            HealthText.SetText(": " + health);
        } else {
            HealthText.SetText(": 0");
        } 
    }

    public GameObject shootNewBullet(Vector3 bulletStartPosition, Vector2 bulletTravelVector) {
        GameObject newBullet = bulletPooler.GetPooledObject();
        if (newBullet != null) {
            newBullet.transform.position = bulletStartPosition;

            BulletBehavior newBulletScript = newBullet.GetComponent<BulletBehavior>();
            newBulletScript.movement = bulletTravelVector;
            newBullet.SetActive(true);
        }
        return newBullet;
    }

    public void GameOver() {
        GameOverText.gameObject.SetActive(true);
        player.SetActive(false);
        isGameOver = true;
    }

    public void PauseGame() {
        if (isGamePaused) {
            PauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
        } else {
            PauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void hideStartScreen() {
        clickToStart = false;
        StartScreenText.gameObject.SetActive(false);
        StartScreenSubText.gameObject.SetActive(false);
        StartScreenBackdrop.gameObject.SetActive(false);
        HealthText.gameObject.SetActive(true);
        BoneSprite.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
