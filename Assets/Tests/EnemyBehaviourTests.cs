using NUnit.Framework;
using UnityEngine;

public class EnemyBehaviourTests
{
    private GameObject enemyGameObject;
    private Enemy_BehaviourScript enemyScript;
    private Animator animatorMock;

    /* 
    Tests in theory should work but while testing we ran out of time with the tests,
    there was an issue with the animator not working that we could not resolve*/
    [SetUp]
    public void SetUp()
    {
        enemyGameObject = new GameObject();
        enemyScript = enemyGameObject.AddComponent<Enemy_BehaviourScript>();
        animatorMock = enemyGameObject.AddComponent<Animator>();
        enemyScript.animator = animatorMock;
        
        enemyScript.attackDistance = 5f;
        enemyScript.moveSpeed = 1f;
        enemyScript.timer = 2f;
        enemyScript.intTimer = 2f;

        GameObject targetGameObject = new GameObject();
        enemyScript.target = targetGameObject;
    }

    [Test]
    public void TestMove()
    {
        enemyScript.inRange = true;
        enemyScript.distance = 6f; 
        
        enemyScript.Move();
        
        Assert.IsTrue(enemyScript.animator.GetBool("canWalk"));
    }

    [Test]
    public void TestAttack()
    {
        enemyScript.distance = 3f; // Within attack range
        enemyScript.cooling = false;

        enemyScript.Attack();

        Assert.IsTrue(enemyScript.attackMode, "Expected enemy to be in attack mode");
        Assert.IsFalse(enemyScript.animator.GetBool("canWalk"), "Expected enemy to stop walking during attack, but it was walking.");
        Assert.IsTrue(enemyScript.animator.GetBool("Attack"), "Expected enemy to perform attack animation. returned false");
    }

    [Test]
    public void TestCooldown()
    {
        enemyScript.cooling = true;
        enemyScript.attackMode = true;
        enemyScript.timer = 0.1f;

        enemyScript.Cooldown();
        
        Assert.IsFalse(enemyScript.cooling, "Expected cooling to end, but it was still charging");
    }
}
