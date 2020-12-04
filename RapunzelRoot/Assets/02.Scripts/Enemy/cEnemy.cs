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
    private float m_fMAxHp;
    [SerializeField]
    [Header("스톤되는높이")]
    private float m_fSpawnYPos;
    [SerializeField]
    [Header("라푼젤위치")]
    private Transform TargetPos;
    [SerializeField]
    [Header("커멘드종류")]
    private string m_sType;


    private Animator animator;
    private Rigidbody2D rigid2d;
    private Vector3 m_v3StartPos;
    private float m_fHp;
    private bool m_bIsDead;
    private float _fStarttime;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        rigid2d = GetComponent<Rigidbody2D>();
        Init();
    }

    public void Init()
    {
        rigid2d.gravityScale = 0.0f;
        m_fHp = m_fMAxHp;
        m_bIsDead = false;
        m_v3StartPos = this.transform.position;
        _fStarttime = 0;
    }
    private void DeadEvent()
    {
        rigid2d.gravityScale = 1.0f;
        rigid2d.AddForce(new Vector2(0, 5));
    }
    private void LookAt2D(Vector3 _Pos)
    {
        Vector3 pos = _Pos;
        Vector3 player_pos = this.transform.position;
        Vector2 targetpos = new Vector2(pos.x - player_pos.x, pos.y - player_pos.y);
        float rad = Mathf.Atan2(targetpos.x, targetpos.y);
        float Rateation = (rad * 180) / Mathf.PI;
        this.transform.localEulerAngles = new Vector3(0, 0, (-Rateation ));

    }


    private void MoveFunction()
    {
        if (Vector3.Distance(this.transform.position, TargetPos.position) >= 0.5f)
        { 
            this.transform.position = Vector3.Lerp(m_v3StartPos, TargetPos.transform.position, _fStarttime);
            _fStarttime += m_fSpeed * Time.deltaTime/10.0f;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (m_bIsDead) return;
            MoveFunction();


        //LookAt2D(TargetPos.position);
    }

    public void HitbyPostion(string _value, int _damage)
    {
        if (m_sType == _value)//설절된 커멘드가 포션커멘드와 같을때
        {
            Hit(_damage);
        }
    }

    private void Hit(float _damage)
    {
        if (m_fHp <= 0)
        {
            m_fHp = 0;
            DeadEvent();
        }
    }

}
