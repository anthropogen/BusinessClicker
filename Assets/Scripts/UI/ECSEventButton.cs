using Leopotam.Ecs;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI
{
    public class ECSEventButton<TEvent> : EntityReferenceMono where TEvent : struct
    {
        [SerializeField] private Button button;

        private void OnEnable()
            => button.onClick.AddListener(() => SendEvent());

        private void OnDisable()
            => button.onClick.RemoveListener(() => SendEvent());

        private void SendEvent()
        {
            if (Entity.IsNull())
                throw new NullReferenceException("Entity is not initialized");

            Entity.Get<TEvent>();
        }
    }
}