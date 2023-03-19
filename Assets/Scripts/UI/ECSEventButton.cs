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

        protected virtual void ConstructEvent(ref TEvent @event) { }


        public void SetInteractable(bool isActive)
            => button.interactable = isActive;

        private void SendEvent()
        {
            if (Entity.IsNull())
                throw new NullReferenceException("Entity is not initialized");
            ConstructEvent(ref Entity.Get<TEvent>());
        }
    }
}