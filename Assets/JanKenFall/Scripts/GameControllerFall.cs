using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerFall : MonoBehaviour {
    public float distance = 3f;
    public float BlockY = -7f;
    internal static bool isPlaying = false;
    internal static float velocityMultiplier = 0.07f;
    //contador de update
    internal static float gameTimer = 0;
    internal static int gameScore = 0;
    internal static int spawnCounter = 1;
    private PlayerFaller player;
    public Direcao direction = Direcao.idle;
    public int position = 0;
    public static float leapDistance = 0.9f;
    private const int maxPosition = 2;
    //public float timerSpawnBlocoMax = 3;
    //public float timerSpawnBloco = 0f;
    public GameObject blockPrefab0;
    public List<GameObject> itemPrefab0;
    public System.Random random;
    public int level1 = 30;
    public int level2 = 60;
    public int level3 = 90;
    public int level4 = 120;
    public Text hudTimer;
    public Text hudScore;
    public int lifes = 3;
    public int updtCounter = 0;
    internal int maxUpdateCounter = 180;
    public List<Image> hearts;
    public Sprite heartOn;
    public Sprite heartOff;

    public const float speed_1 = 0.04f;
    public const float speed0 = 0.05f;
    public const float speed1 = 0.07f;
    public const float speed2 = 0.09f;
    public const float speed3 = 0.10f;

    public const int spawn_1 = 180;
    public const int spawn0 = 150;
    public const int spawn1 = 120;
    public const int spawn2 = 90;
    public const int spawn3 = 80;

    public const int stage0Duration = 30;
    public const int stage1Duration = 60;
    public const int stage2Duration = 90;
    public const int stage3Duration = 120;

    void Start() {
        isPlaying = true;
        player = FindObjectOfType<PlayerFaller>();
        random = new System.Random();
        lifes = hearts.Count;
        maxUpdateCounter = spawn1;
        velocityMultiplier = speed0;
        gameTimer = 0;
        gameScore = 0;
        spawnCounter = 1;
    }
    public enum Dificuldades {
        muitolento = 0,
        lento,
        normal,
        rapido,
        muitorapido
    }
    public void SetDifficulty(Dificuldades en) {
        switch (en) {
            case Dificuldades.muitolento:
                velocityMultiplier = speed_1;
                maxUpdateCounter = spawn_1;
                break;
            case Dificuldades.lento:
                velocityMultiplier = speed0;
                maxUpdateCounter = spawn0;
                break;
            case Dificuldades.normal:
                velocityMultiplier = speed1;
                maxUpdateCounter = spawn1;
                break;
            case Dificuldades.rapido:
                velocityMultiplier = speed2;
                maxUpdateCounter = spawn2;
                break;
            case Dificuldades.muitorapido:
                velocityMultiplier = speed3;
                maxUpdateCounter = spawn3;
                break;
            default:
                break;
        }
        Debug.Log("Vel:" + velocityMultiplier + " Spawn:" + maxUpdateCounter);
    }
    public void Scoretimer() {
        if (lifes >= 3) { // inicio
            Debug.Log("FASE0");
            if (gameScore > 100) { // indo bem
                //rapido
                SetDifficulty(Dificuldades.muitorapido);
            } else if (gameScore > 30) { // indo medio
                // normal
                SetDifficulty(Dificuldades.rapido);
            } else { // indo mal
                //lento
                SetDifficulty(Dificuldades.normal);
            }
        } else if (lifes >= 2) {
            if (gameScore > 100) {
                SetDifficulty(Dificuldades.muitorapido);
            } else if (gameScore > 30) {
                SetDifficulty(Dificuldades.normal);
            } else {
                SetDifficulty(Dificuldades.lento);
            }
        } else { // fim
            if (gameScore > 100) {
                SetDifficulty(Dificuldades.normal);
            } else if (gameScore > 30) {
                SetDifficulty(Dificuldades.lento);
            } else {
                SetDifficulty(Dificuldades.muitolento);
            }
        }
        Debug.Log(gameScore);
    }
    void SortearLinha() {
        //Debug.Log("ok");
        //Scoretimer();
        int[] lista = new int[5];
        for (int i = 0; i < lista.Length; i++) {
            lista[i] = i - 2;//as posicoes vao de -2 a 2
        }
        ShuffleList(lista);
        int aleatorio = random.Next(0, 100);
        int joken = random.Next(0, 100);
        if (joken < 33) {
            joken = 0;
        } else if (joken < 66) {
            joken = 1;
        } else {
            joken = 2;
        }

        //Debug.Log(gameTimer);
        if (gameTimer <= level1) {// instancia 1
            InstantiateBlock(lista[0]);
            if (aleatorio < 70) {
                GameObject goo = Instantiate(itemPrefab0[joken]);
                goo.transform.position = new Vector3(lista[4] * leapDistance, BlockY);
                spawnCounter += 1;
            }
        } else if (gameTimer <= level2) { // instancia 2
            for (int i = 0; i < 1; i++) {
                InstantiateBlock(lista[i]);
            }
            if (aleatorio < 80) {
                GameObject goo = Instantiate(itemPrefab0[joken]);
                goo.transform.position = new Vector3(lista[4] * leapDistance, BlockY);
                spawnCounter += 1;
            }
        } else if (gameTimer <= level3) { // instancia 3
            for (int i = 0; i < 2; i++) {
                InstantiateBlock(lista[i]);
            }
            if (aleatorio < 90) {
                GameObject goo = Instantiate(itemPrefab0[joken]);
                goo.transform.position = new Vector3(lista[4] * leapDistance, BlockY);
                spawnCounter += 1;
            }
        } else {//if (gameTimer <= level4) { // instancia 3
            for (int i = 0; i < 3; i++) {
                InstantiateBlock(lista[i]);
            }
            GameObject goo = Instantiate(itemPrefab0[random.Next(0, itemPrefab0.Count)]);
            goo.transform.position = new Vector3(lista[4] * leapDistance, BlockY);
            spawnCounter += 1;
        }
    }
    void InstantiateBlock(int pos) {
        GameObject g = Instantiate(blockPrefab0);
        g.transform.position = new Vector3(pos * leapDistance, BlockY);
    }
    private void ShuffleList(int[] lista) {
        for (int i = 0; i < lista.Length; i++) {
            int rnd = random.Next(0, lista.Length);
            int swap = lista[i];
            lista[i] = lista[rnd];
            lista[rnd] = swap;
        }
    }
    public void Hurt() {
        lifes--;
        for (int i = 0; i < hearts.Count; i++) {
            hearts[i].sprite = (lifes > i ? heartOn : heartOff);
        }
    }
    void Update() {
        if (isPlaying) {
            updtCounter++;
            Debug.Log(lifes);
            if (lifes <= 0) {
                isPlaying = false;
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            }
            Scoretimer();
            gameTimer += Time.deltaTime;
            foreach (Text item in hudTimer.GetComponentsInChildren<Text>()) {
                item.text = ((int)gameTimer).ToString();
            }
            foreach (Text item in hudScore.GetComponentsInChildren<Text>()) {
                item.text = ((int)gameScore).ToString();
            }
            //timerSpawnBloco += Time.deltaTime;
            if (updtCounter >= maxUpdateCounter) {
                updtCounter = 0;
                SortearLinha();
            }
            if (player != null) {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
                    direction = Direcao.left;
                    FindObjectOfType<PlayerFaller>().playSound();
                } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
                    direction = Direcao.right;
                    FindObjectOfType<PlayerFaller>().playSound();
                } else if (true) {
                    direction = Direcao.idle;
                }
                switch (direction) {
                    case Direcao.idle:
                        break;
                    case Direcao.left:
                        if (position > -maxPosition) {
                            position--;
                        }
                        break;
                    case Direcao.right:
                        if (position < maxPosition) {
                            position++;
                        }
                        break;
                    default:
                        break;
                }
                if (direction != Direcao.idle) {
                    player.transform.position = new Vector3(position * leapDistance, distance);
                }
                /*/direction = Direcao.idle;
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
                    direction = Direcao.left;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
                    direction = Direcao.right;
                }*/
            }
            /*if (direction != Direcao.idle) {
                float step = 0.2f * Time.deltaTime; // calculate distance to move
                player.transform.position = Vector3.MoveTowards(player.transform.position,
                    player.transform.position + (new Vector3(position * leapDistance, 0)),
                    step);
            }*/
        }
    }
}

public enum Direcao {
    idle = 0, left, right
}