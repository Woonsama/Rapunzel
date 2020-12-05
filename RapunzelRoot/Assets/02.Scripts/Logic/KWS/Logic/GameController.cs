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

    [Header("Liquor Generator")]
    public LiquorGenerator liquorGenerator;
    public Transform liquorGeneratePos;
    public GameObject liquorParent;

    private bool isWaveClear;

    protected override IEnumerator OnAwakeCoroutine()
    {
        while(!isWaveClear)
        {
            Init();
            yield return StartCoroutine(Command_Coroutine());
            yield return StartCoroutine(Shooter_Coroutine());
            yield return StartCoroutine(Fire_Coroutine());
            yield return null;
        }

    }

    private void Init()
    {
        shooter.gameObject.SetActive(false);
        command.ReleaseCommand();
        isWaveClear = false;
    }

    private IEnumerator Command_Coroutine()
    {
        while(!command.isCorrectCommand)
        {
            yield return null;
        }
        command.isCorrectCommand = false;
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
        liquorGenerator.GenerateLiquor(command.liquorIndex,liquorGeneratePos, liquorParent.transform);        
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
