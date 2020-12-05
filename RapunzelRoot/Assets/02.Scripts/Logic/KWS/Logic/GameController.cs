using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : ObjectBase
{
    [Header("Command")]
    public Command command;

    [Header("Shooter")]
    public Shooter shooter;

    [Header("Player")]
    public Player player;

    protected override IEnumerator OnAwakeCoroutine()
    {
        Init();
        yield return StartCoroutine(Command_Coroutine());
        yield return StartCoroutine(Shooter_Coroutine());
        yield return StartCoroutine(Fire_Coroutine());
    }

    private void Init()
    {
        shooter.gameObject.SetActive(false);
    }

    private IEnumerator Command_Coroutine()
    {
        while(!command.isCorrectCommand)
        {
            yield return null;
        }
    }

    private IEnumerator Shooter_Coroutine()
    {
        shooter.gameObject.SetActive(true);

        bool isFire = false;

        while(!isFire)
        {
            shooter.Do_Move();

            if (Input.GetKeyDown(KeyCode.Space))
                isFire = true;

            yield return null;
        }
        yield break;
    }

    private IEnumerator Fire_Coroutine()
    {

        yield break;
    }

    private IEnumerator ClearCheck_Coroutine()
    {
        while(!player.isDie)
        {            
            yield return null;
        }
    }
}
