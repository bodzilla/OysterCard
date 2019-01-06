using OysterCard.Core.Mappings;

namespace OysterCard.UnitTests.Services
{
    internal static class ServicesInitializer
    {
        private static bool _configured;

        public static void ConfigureMappings()
        {
            if (_configured) return;
            MappingConfiguration.Configure();
            _configured = true;
        }
    }
}
