namespace Hero
{
    public class Run:State
    { 
        public Hero _Hero;
        public Run(Hero hero)
        {
            _Hero = hero;
        }
        public void OnStateEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnStateUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void OnStateExit()
        {
            throw new System.NotImplementedException();
        }
    }
}