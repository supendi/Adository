namespace Adository.CSharp.UI.Generator
{
    public abstract class GeneratorCommandBase
    {
        protected abstract void InitEvents();

        protected GeneratorForm Form { get; private set; }

        public GeneratorCommandBase(GeneratorForm form)
        {
            Form = form;
            InitEvents();
        }
    }
}
