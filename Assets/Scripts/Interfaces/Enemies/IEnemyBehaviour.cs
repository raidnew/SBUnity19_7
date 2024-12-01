public interface IEnemy
{
    void Move(float direction);
    void Attack();
    void Wait();
    bool CanAttack();
    bool CanMove();
    bool IsDied();

}
