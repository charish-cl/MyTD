namespace Manage
{
    public class GameData:Singleton<GameData>
    {
        public int coin{ get; set; }
        public int base_hp  { get; set; }

        public GameData()
        {
            Init();
        }
        public void Init(int coin=40,int base_hp=20 )
        {
            this.coin = coin;
            this.base_hp = base_hp;
        }
    }
}