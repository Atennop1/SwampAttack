namespace SwampAttack.Runtime.Weapons
{
    public interface IWeapon
    {
        int Bullets { get; }
        bool CanShoot { get; }

        void Shoot();
        void AddBullets(int count);
    }
}