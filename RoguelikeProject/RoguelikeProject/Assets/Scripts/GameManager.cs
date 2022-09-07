using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float turnDelay = .1f;
    //���� �Ŵ����� �̱������� �����
    //�̱����� ���� �� ������ �� �ϳ��� �ν��Ͻ��� ������ �� �ִ� ������Ʈ�̴�.
    //���� �Ŵ����� ������ �ε��ϰų�, �÷��̾� ���ھ �����Ѵٴ��� �ϱ� ������ �� ������Ʈ�� �ϳ� �̻� ���� �ʿ䰡 ����.
    //�׷��� �ڵ�� Ȯ���� �����ִ� ���̴�!
    public static GameManager instance = null;
    //�̷��� �ϸ� ���� �Ŵ����� public �Լ��� �������� � ��ũ��Ʈ������ ���� �� �� �ִٴ� �̾߱��̴�.
    public BoardManager boardScript;
    public int playerFoodPoints = 100;
    [HideInInspector] public bool playersTurn = true;

    private int level = 3;
    private List<Enemy> enemies;
    private bool enemiesMoving;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        enemies = new List<Enemy>();
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        enemies.Clear();
        boardScript.SetupScene(level);
    }

    public void AddEnemyToList(Enemy script)
    {
        enemies.Add(script);
    }

    public void GameOver()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playersTurn || enemiesMoving)
            return;

        StartCoroutine(MoveEnemies());
    }

    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;

        yield return new WaitForSeconds(turnDelay);

        if (enemies.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].MoveEnemy();

            yield return new WaitForSeconds(enemies[i].moveTime);
        }
        playersTurn = true;

        enemiesMoving = false;
    }
}