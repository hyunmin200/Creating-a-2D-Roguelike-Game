using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //게임 매니저를 싱글턴으로 만들기
    //싱글턴은 게임 상에 언제나 단 하나의 인스턴스만 존재할 수 있는 오브젝트이다.
    //게임 매니저는 레벌을 로드하거나, 플레이어 스코어를 관리한다던가 하기 때문에 이 오브젝트가 하나 이상 있을 필요가 없다.
    //그래서 코드로 확실히 막아주는 것이다!
    public static GameManager instance = null;
    //이렇게 하면 게임 매니저의 public 함수와 변수들은 어떤 스크립트에서도 접근 할 수 있다는 이야기이다.
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
