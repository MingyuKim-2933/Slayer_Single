//Enemy.cs

using System.Collections;
using UnityEngine;
using UnityEngine.AI; // AI, 내비게이션 시스템 관련 코드를 가져오기

// 적 AI를 구현한다
public class BossEnemy : LivingEntity
{
    public LayerMask whatIsTarget; // 추적 대상 레이어

    private LivingEntity targetEntity; // 추적할 대상
    private NavMeshAgent pathFinder; // 경로계산 AI 에이전트

    public ParticleSystem hitEffect; // 피격시 재생할 파티클 효과
    public AudioClip deathSound; // 사망시 재생할 소리
    public AudioClip hitSound; // 피격시 재생할 소리

    private Animator enemyAnimator; // 애니메이터 컴포넌트
    private AudioSource enemyAudioPlayer; // 오디오 소스 컴포넌트
    private Renderer enemyRenderer; // 렌더러 컴포넌트

    public float bossDamage = 30f; // 공격력
    public float bossTimeBetAttack = 0.5f; // 공격 간격
    private float lastAttackTime; // 마지막 공격 시점

    // 추적할 대상이 존재하는지 알려주는 프로퍼티
    private bool hasTarget
    {
        get
        {
            // 추적할 대상이 존재하고, 대상이 사망하지 않았다면 true
            if (targetEntity != null && !targetEntity.dead)
            {
                return true;
            }

            // 그렇지 않다면 false
            return false;
        }
    }

    private void Awake()
    {
        // 초기화

        //게임 오브젝트로부터 사용할 컴포넌트 가져오기
        pathFinder = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        enemyAudioPlayer = GetComponent<AudioSource>();

        //렌더러 컴포넌트는 자식 게임 오브젝트에 있으므로
        //GetComponentInChildren() 메서드 사용
        enemyRenderer = GetComponentInChildren<Renderer>();
    }

    // 적 AI의 초기 스펙을 결정하는 셋업 메서드
    public void Setup(float newHealth, float newDamage, float newSpeed, Color skinColor)
    {
        //체력 설정
        startingHealth = newHealth;
        health = newHealth;
        //공격력 설정
        bossDamage = newDamage;
        //내비메시 에이전트의 이동 속도 설정
        pathFinder.speed = newSpeed;
        //렌더러가 사용 중인 머티리얼의 컬러를 변경, 외형 색이 변함
        enemyRenderer.material.color = skinColor;
    }

    private void Start()
    {
        // 게임 오브젝트 활성화와 동시에 AI의 추적 루틴 시작
        StartCoroutine(UpdatePath());
    }

    private void Update()
    {
        // 추적 대상의 존재 여부에 따라 다른 애니메이션을 재생
        enemyAnimator.SetBool("HasTarget", hasTarget);
    }

    // 주기적으로 추적할 대상의 위치를 찾아 경로를 갱신
    private IEnumerator UpdatePath()
    {
        // 살아있는 동안 무한 루프
        while (!dead)
        {
            if (hasTarget)
            {
                //추적 대상 존재 : 경로를 갱신하고 AI 이동을 계속 진행
                pathFinder.isStopped = false;
                pathFinder.SetDestination(targetEntity.transform.position);
                enemyAnimator.SetTrigger("Move");
            }
            else
            {
                //추적 대상 없음 : AI 이동 중지
                pathFinder.isStopped = true;

                //20유닛의 반지름을 가진 가상의 구를 그렸을 때 구와 겹치는 모든 콜라이더를 가져옴
                //단, whatIsTarget 레이어를 가진 콜라이더만 가져오도록 필터링
                Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, whatIsTarget);

                //모든 콜라이더를 순회하면서 살아있는 LivingEntity 찾기
                for (int i = 0; i < colliders.Length; i++)
                {
                    //콜라이더로부터 LivingEntity 컴포넌트 가져오기
                    LivingEntity livingEntity = colliders[i].GetComponent<LivingEntity>();

                    //LivingEntity 컴포넌트가 존재하며, 해당 LivingEntity가 살아있다면
                    if (livingEntity != null && !livingEntity.dead)
                    {
                        //추적 대상을 해당 LivingEntity로 설정
                        targetEntity = livingEntity;

                        //for문 즉시 정지
                        break;
                    }
                }
            }

            // 0.25초 주기로 처리 반복
            yield return new WaitForSeconds(0.25f);
        }
    }

    // 데미지를 입었을때 실행할 처리
    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        enemyAnimator.SetTrigger("Damage");

        Debug.Log("Enemy.OnDamage");
        // LivingEntity의 OnDamage()를 실행하여 데미지 적용
        base.OnDamage(bossDamage, hitPoint, hitNormal);
        //아직 사망하지 않은 경우에만 피격 효과 재생
        if (!dead)
        {
            //공격 받은 지점과 방향으로 파티클 효과 재생
            hitEffect.transform.position = hitPoint;
            hitEffect.transform.rotation = Quaternion.LookRotation(hitNormal);
            hitEffect.Play();

            //피격 효과음 재생
            enemyAudioPlayer.PlayOneShot(hitSound);
        }

    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }


    // 사망 처리
    public override void Die()
    {
        // LivingEntity의 Die()를 실행하여 기본 사망 처리 실행
        base.Die();

        //다른 AI를 방해하지 않도록 자신의 모든 콜라이더를 비활성화
        Collider[] enemyColliders = GetComponents<Collider>();
        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }

        //AI 추적을 중지하고 내비메시 컴포넌트 비활성화
        pathFinder.isStopped = true;
        pathFinder.enabled = false;

        //사망 애니메이션 재생
        enemyAnimator.SetTrigger("Die");
        //사망 효과음 재생
        enemyAudioPlayer.PlayOneShot(deathSound);

        StartCoroutine(WaitDestroy());

        Debug.Log("EnemyDie");
        GameManager.instance.AddCount(1);

        // *** 오브젝트 제거 
        Destroy(gameObject, 2f);

    }


    private void OnTriggerStay(Collider other)
    {
        // 트리거 충돌한 상대방 게임 오브젝트가 추적 대상이라면 공격 실행

        //자신이 사망하지 않았으며,
        //최근 공격 시점에서 timeBetAttack 이상 시간이 지났다면 공격 가능
        if (!dead && Time.time >= lastAttackTime + bossTimeBetAttack)
        {
            //상대방의 LivingEntity 타입 가져오기 시도
            LivingEntity attackTarget = other.GetComponent<LivingEntity>();

            //상대방의 LivingEntity가 자신의 추적 대상이라면 공격 실행
            if (attackTarget != null && attackTarget == targetEntity)
            {
                int index = Random.Range(0, 3);
                Debug.Log(index);

                //최근 공격 시간 갱신
                lastAttackTime = Time.time;

                //상대방의 피격 위치와 피격 방향을 근사값으로 계산
                Vector3 hitPoint = other.ClosestPoint(transform.position);
                Vector3 hitNormal = transform.position - other.transform.position;
                if (index == 0)
                {
                    // 공격1 애니메이터 호출
                    enemyAnimator.SetTrigger("Attack01");
                }

                if (index == 1)
                {
                    bossDamage = 40f;
                    // 공격2 애니메이터 호출
                    enemyAnimator.SetTrigger("Attack02");
                }

                if (index == 2)
                {
                    // 공격3 애니메이터 호출
                    bossDamage = 40f;
                    enemyAnimator.SetTrigger("Attack03");
                }
                // *** 공격 애니메이터 호출
                enemyAnimator.SetTrigger("Attack");

                //공격 실행
                attackTarget.OnDamage(bossDamage, hitPoint, hitNormal);
            }
        }
    }
}