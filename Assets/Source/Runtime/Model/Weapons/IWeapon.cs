namespace SwampAttack.Runtime.Model.Weapons
{
    public interface IWeapon
    {
        int MaxBullets { get; }
        int Bullets { get; }
        bool CanShoot { get; }

        void Shoot();
        void AddBullets(int count);
    }
}