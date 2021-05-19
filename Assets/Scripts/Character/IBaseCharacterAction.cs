namespace Character
{
    public interface IBaseCharacterAction
    {
        void Attack();
        
        void OnDamage(float damage);
        
        void OnDead();
    }
}