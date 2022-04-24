using BoDi;
using SpecFlowProject.Drivers;
using SpecFlowProject.Utils;

namespace SpecFlowProject
{
    [Binding]
    public class Startup
    {
        //Read more about Hooks: https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html
        [BeforeScenario(Order = ScenarioOrders.Initialize)]
        public static void RegisterServices(IObjectContainer objectContainer)
        {
            //HttpClients
            objectContainer.AddRefitClient<IGroupsApiClient>(ConfigureSmartChargingApiClient());
        }

        private static Action<HttpClient> ConfigureSmartChargingApiClient()
        {
            return c =>
            {
                var baseAddress = "https://gfx-smartcharging-assignment-api.azurewebsites.net";
                c.BaseAddress = new Uri(baseAddress);
            };
        }
    }
}
