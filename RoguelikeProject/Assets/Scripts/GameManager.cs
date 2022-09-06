using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //���� �Ŵ����� �̱������� �����
    //�̱����� ���� �� ������ �� �ϳ��� �ν��Ͻ��� ������ �� �ִ� ������Ʈ�̴�.
    //���� �Ŵ����� ������ �ε��ϰų�, �÷��̾� ���ھ �����Ѵٴ��� �ϱ� ������ �� ������Ʈ�� �ϳ� �̻� ���� �ʿ䰡 ����.
    //�׷��� �ڵ�� Ȯ���� �����ִ� ���̴�!
    public static GameManager instance = null;
    //�̷��� �ϸ� ���� �Ŵ����� public �Լ��� �������� � ��ũ��Ʈ������ ���� �� �� �ִٴ� �̾߱��̴�.
    public BoardManager boardScript;

    private int level = 3;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupScene(level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
