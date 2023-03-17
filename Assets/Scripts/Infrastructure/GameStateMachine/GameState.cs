namespace Clicker.Infrastructure
{
    public class GameState : IRunGameState
    {
        public void Enter()
        {

        }

        public void Exit()
        {
            UnityEngine.Debug.Log("dispose game");
        }

        public void Run()
        {

        }
    }
}
