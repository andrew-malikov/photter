using LightInject;

namespace Photter {
    public abstract class Context {
        public readonly ServiceContainer ServiceProvider;

        public Context() : this(new ServiceContainer()) { }

        public Context(ServiceContainer container) {
            ServiceProvider = container;
        }

        protected abstract void ConfigureServices(ServiceContainer container);
    }
}