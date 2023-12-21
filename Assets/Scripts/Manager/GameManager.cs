using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    [SerializeField] protected GameObject player;

    private void Awake()
    {
        // 스테이지 초기화, 플레이어 상태 초기화, 등등 처리해주기
        Instantiate(player, new Vector3(0,.5f,0),Quaternion.identity);
    }
}
