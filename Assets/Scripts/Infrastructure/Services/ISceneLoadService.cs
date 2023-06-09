﻿using System;

namespace Clicker.Infrastructure
{
    public interface ISceneLoadService : IService
    {
        void LoadLevel(string name, Action onCompleted = null);
    }
}