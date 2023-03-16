using System;

namespace Clicker.Infrastructure
{
    public interface IGameState 
    {
        void Enter();
        void Run();
        void Exit();
    }
}
