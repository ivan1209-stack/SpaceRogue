using Zenject;

namespace Installers
{
    public class GlobalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMainCanvas();
        }

        private void BindMainCanvas()
        {
            
        }
    }
}