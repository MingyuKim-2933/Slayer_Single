using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyState
{
    Idle,
    Move,
    Attack,
    Damage,
    Die
}

public class KE_Enemy : MonoBehaviour
{
   
// - 경과시간
float currentTime;

    #region "Idle 속성"
    // - 일정시간(정지시간)
    public float idleTime = 2;
    #endregion

    #region "Move 속성"
    // - 타겟
    public Transform target;
    // - 이동속도
    public float moveSpeed = 5;
    // Character controller 를 이용하여 이동처리
    CharacterController cc;
    #endregion

    #region "Attack 상태 속성"
    public float attackRange = 2;
    public float attackDelayTime = 2;
    #endregion

    #region "Damage 상태 속성"
    public float damageDelayTime = 2;
    #endregion

    #region "Animation"
    // animation 제어를 위해 필요한 컴포넌트 Enemy 의 child에 있다.
    Animator anim;
    #endregion

    EnemyState myState = EnemyState.Idle;


    void Start()
    {
        cc = GetComponent<CharacterController>();
        // 자식에 붙어 있는 Animator 컴포넌트 가져오기
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            hp--;
            Debug.Log("hp=" + hp);
        }

        print("State : " + myState);
        // - 정지, 이동, 공격, 피격, 죽음
        switch (myState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Damage:
                Damage();
                break;
            case EnemyState.Die:
                Die();
                break;
        }
        //Debug.Log(hp);
    }

    private void Idle()
    {
        // 일정시간 동안 기다렸다가 상태를 Move 로 전환하고 싶다.
        // 1. 경과시간이 흘렀으니까..
        currentTime += Time.deltaTime;
        // 2. 경과시간이 일정시간(정지시간) 보다 커졌으니까
        if (currentTime > idleTime)
        {
            // 3. 상태를 Move 로 전환하고 싶다.
            myState = EnemyState.Move;
            // animation 의 상태를 Move 로 전환하고 싶다.
            anim.SetTrigger("Move");
        }
    }

    //타겟 방향으로 회전한다 
    //타켓 방향으로 이동한다 
    // transition 조건 
    //공격 범위안에 들어오면 상태 attack
    private void Move()
    {
        //target으로 이동
        Vector3 dir = target.position - transform.position;
        //이동하면 character controller 발동
        cc.SimpleMove(dir.normalized * moveSpeed);

        //transition 조건
        //- 공격범위 안에 들어오면 상태를 Attack 으로 전환
        // 만약 타겟과 나와의 거리가 공격범위보다 작으면
        // dir => Vector : 크기(거리) + 방향

        if (dir.magnitude < attackRange)
        {
            myState = EnemyState.Attack;
            currentTime = attackDelayTime;
        }

        // 3. target 방향으로 회전
        //transform.LookAt(target);
        // 부드럽게 회전 시키자
        dir.y = 0;
        //transform.forward = dir.normalized;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir.normalized), 10 * Time.deltaTime);
    }

    private void Attack()
    {
        currentTime += Time.deltaTime;

        if(currentTime > attackDelayTime)
        {
            currentTime = 0;
            Debug.Log("공격");
            anim.SetTrigger("Attack");

        }
        //- 공격범위를 벗어나면 상태를 Move 으로 전환
        if (Vector3.Distance(target.position, transform.position)> attackRange + 0.5f)
        {
            myState = EnemyState.Move;
            anim.SetTrigger("Move");
        }
    }

    //enemy hp 감소 및 상태 die 변환
    public int hp = 3;

    public void OnDamageProcess()
    {
        // 만약 state 가 Die 일경우는 아래 처리하지 않는다.
        if (myState == EnemyState.Die)
        {
            return;
        }
        //1. hp 감소.
        hp--;
        currentTime = 0;
        //2. 만약 hp 가 0이하면 상태를 die 로
        if (hp <= 0)
        {
            Debug.Log(hp);
            myState = EnemyState.Die;
        }
        //3. 그렇지 않으면 상태를 damage 로 전환
        else
        {
            myState = EnemyState.Damage;
            // Damage 코루틴 시작
            //StartCoroutine(Damage());
            StartCoroutine("Damage");
        }
    }

    private IEnumerator Damage()
    {
        //일정 시간 기다렸다가 
        // damageDelayTime 만큼 기다리고싶다.(양보할래)
        yield return new WaitForSeconds(damageDelayTime);
        myState = EnemyState.Idle;
    }

    public float dieDelayTime = 2;
    private void Die()
    {
        currentTime += Time.deltaTime;
        if (currentTime > dieDelayTime)
        {
            Destroy(gameObject);
        }
    }
}
