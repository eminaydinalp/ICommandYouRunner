using _Game.Scripts.Abstracts.Controller;
using _Game.Scripts.Abstracts.Movement;
using _Game.Scripts.Concretes.Controllers;
using UnityEngine;

namespace _Game.Scripts.Concretes.Movement
{
    public class VerticalMovement : IMover
    {
        private IEntityController _entityController;

        public VerticalMovement(IEntityController entityController)
        {
            _entityController = entityController;
        }

        public void Move(float direction, float speed)
        {
            _entityController.transform.Translate(_entityController.transform.forward * (speed * direction * Time.deltaTime));
        }
    }
}
