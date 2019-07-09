using LightInject;

namespace Photter {
    public abstract class Context {
        private readonly ServiceContainer ServiceProvider;

        public Context() : this(new ServiceContainer()) { }

        public Context(ServiceContainer container) {
            ServiceProvider = container;
        }

        public ServiceContainer Prepare() {
            ConfigureServices(ServiceProvider);

            return ServiceProvider;
        }

        protected abstract void ConfigureServices(ServiceContainer container);
    }
}