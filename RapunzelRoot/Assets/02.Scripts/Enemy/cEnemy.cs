using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEnemy : MonoBehaviour
{
    [SerializeField]
    [Header("속도")]
    private float m_fSpeed;
    [SerializeField]
    [Header("최대체력")]
    private float m_fMaxHp;
    [SerializeField]
    [Header("몬스터종류")]
    private int m_nType;
    [SerializeField]
    [Header("죽을때위로뜨는값")]
    private float m_fDeadJumpValue;
    [SerializeField]
    [Header("적용될중력값")]
    private float m_fGravityValue;

    private Animator animator;
    private Rigidbody2D rigid2d;
    private Vector3 m_v3StartPos;
    private float m_fHp;
    private bool m_bIsDead;
    private float _fStarttime;
    private cScorePlus cSP;
    private Transform m_trTargetPos;


    // Start is called before the first frame update
    void Awake()
    {
        cSP = GetComponent<cScorePlus>();
        animator = GetComponent<Animator>();
        rigid2d = GetComponent<Rigidbody2D>();
        Init(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Hit(123);
        }
        if (m_bIsDead == true)
        {
            ObjectDestoryEvent();
        }
        else
        {
            MoveFunction();
        }
        //LookAt2D(TargetPos.position);
    }
    public void SetMaxHp(float _value)
    {
        m_fMaxHp = _value;
    }
    public void Init(float _fMaxHp,int _Upgrade)
    {
        m_trTargetPos = GameObject.FindGameObjectWithTag("Player").transform;
        m_fSpeed = Random.Range(1.0f, _Upgrade + 1);
        rigid2d.gravityScale = 0.0f;
        m_v3StartPos = this.transform.position;
        m_fHp = _fMaxHp;
        m_bIsDead = false;
        _fStarttime = 0;
        cSP.SetScoreNMoney((_Upgrade * 2)+1, (_Upgrade*2)+1);
    }
    private void DeadEvent()
    {
        cSP.AddMoney();
        cSP.AddScore();
        m_bIsDead = true;
        rigid2d.gravityScale = m_fGravityValue;
        rigid2d.AddForce(new Vector2(0, m_fDeadJumpValue));
        animator.SetTrigger("IsDead");
    }
    private void MoveFunction()
    {
        if (Vector3.Distance(this.transform.position, m_trTargetPos.position) >= 0.1f)
        { 
            this.transform.position = Vector3.Lerp(m_v3StartPos, m_trTargetPos.transform.position, _fStarttime);
            _fStarttime += m_fSpeed * Time.deltaTime/10.0f;
        }
    }
    private void ObjectDestoryEvent()
    {
        if (this.transform.position.y <= -20.0f)
        {
            cEnemyDeadCheck.instance.MinusEnemyCount();
            if (cEnemyDeadCheck.instance.IsGameOver())
            {

            }
            Destroy(this.gameObject);
        }
    }

    public void HitbyPotion(int _value, int _damage)
    {
        if (m_nType == _value)//설절된 커멘드가 포션커멘드와 같을때
        {
            Hit(_damage);
        }
    }

    private void Hit(float _damage)
    {
        m_fHp -= _damage;
        if (m_fHp <= 0)
        {
            m_fHp = 0;
            DeadEvent();
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//플레이어랑 충돌하면
        {
            Destroy(this.gameObject);
            //플레이어 체력감소
        }
        if (collision.CompareTag("Liquor"))//포션이랑랑 충돌하면
        {
            // csakedsaa.getcomad<adfwasd>().returnvasdldwa
            //HitbyPosion
            HitbyPotion(1,10);
            //플레이어 체력감소
        }
    }

}
