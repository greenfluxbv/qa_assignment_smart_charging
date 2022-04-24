using SpecFlowProject.Context;
using SpecFlowProject.Drivers;
using SpecFlowProject.Utils;

namespace SpecFlowProject.Hooks
{
    [Binding]
    public class CleanUpGroupHook
    {
        //Read more about Hooks: https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html
        [AfterScenario(Order = ScenarioOrders.Cleanup)]
        public static async Task CleanUpGroups(GroupContext groupContext, IGroupsApiClient groupsApiClient)
        {
            if (groupContext.CurrentGroupId != null)
            {
               await groupsApiClient.DeleteGroup(groupContext.CurrentGroupId.Value);
               groupContext.CurrentGroupId = null;
            }
        }
    }
}
