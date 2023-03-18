using Leopotam.Ecs;
using UnityEngine;

namespace Clicker
{
    public class EntityReferenceMono : MonoBehaviour
    {
        protected EcsEntity Entity;

        public void Construct(EcsEntity entity)
            => Entity = entity;
    }
}