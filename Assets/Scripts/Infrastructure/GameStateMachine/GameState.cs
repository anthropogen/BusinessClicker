using System;

namespace Clicker.Infrastructure
{
    public class GameState : IGameState, IDisposable
    {
        public void Enter()
        {

        }

        public void Exit()
        {

        }

        public void Run()
        {

        }

        public void Dispose()
        {
            UnityEngine.Debug.Log("dispose game");
        }
    }
}
