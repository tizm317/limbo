using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    EnemyState _stat;
    [SerializeField] GameObject _lockTarget;
    [SerializeField] float scanRange = 10.0f;  //player 사정 거리
    // [SerializeField] float attackRange = 2.0f;  //공격 사정 거리
                                     
    void init()
    {
        _stat = gameObject.GetComponent<EnemyState>();  //EnemyState Script 받음
        GameObject player = GameObject.FindGameObjectWithTag("Player");  //Tag를 이용하여 "player" 인식
        if (player == null)
            return;  //player가 없으면 대기
        float distance = (player.transform.position - transform.position).magnitude;  // player와의 거리 체크
        if(distance < scanRange)  // player와의 거리가 사정거리보다 작은 경우
        {
            _lockTarget = player;
            //State = Define.State.moving;
            return;
        }
    }

    void UpdateIdle()
    {
        Debug.Log("Enemy UpdateIdle");
    }
    void UpdateMoving()
    {
        Debug.Log("Enemy UpdateMoving");
    }
    void UpdateSkill()
    {
        Debug.Log("Enemy UpdateSkill");
    }

    void OnHitEvent()
    {
        Debug.Log("Enemy OnHitEvent");
    }
}
