using UnityEngine;

public class CharStats : LivingEntity
{
    public Stat damage;
    public Stat armor;
    EnemyController enemyController;
    Animator playerAnimator;
    protected override void Start()
    {
        base.Start();
        enemyController = GetComponent<EnemyController>();
        playerAnimator = PlayerTracker.instance.GetComponentInChildren<Animator>();
    }
    public override void Interact()
    {
        if(this.isDead)
        {
            playerAnimator.Play("Locomotion");
        }
        if (this.getCurrentHealth() <= 0)
        {
            playerAnimator.Play("Locomotion");
            
        }
        else
        {
            playerAnimator.Play("Player_Attack");
        }

        



    }

}
