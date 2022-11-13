using _Game.Scripts.Abstracts.Affect;
using _Game.Scripts.Abstracts.Lenses;
using _Game.Scripts.Concretes.Managers;

namespace _Game.Scripts.Concretes.Lenses
{
    public class LensDecrease : LensBase, IAffectable
    {
        protected override void Start()
        {
            base.Start();
            
            SetGateText();
        }

        public override void DoProcess()
        {
            base.DoProcess();
            EventManager.OnTriggerLensDecrease?.Invoke(randomNumber);
        }
        
        private void SetGateText()
        {
            gateNo.text = "-" + randomNumber.ToString();
        }
    }
}