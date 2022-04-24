using SpecFlowProject.Context;
using SpecFlowProject.Drivers;

namespace SpecFlowProject.StepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
    [Binding]
    public sealed class GroupStepDefinitions
    {
        private readonly GroupContext _groupContext;
        private readonly IGroupsApiClient _groupsApiClient;

        public GroupStepDefinitions(GroupContext groupContext, IGroupsApiClient groupsApiClient)
        {
            _groupContext = groupContext;
            _groupsApiClient = groupsApiClient;
        }

        [Given(@"a group of charge stations with capacity (\d+) A")]
        public async Task GivenAGroupOfChargeStationsWithCapacityA(int capacity)
        {
            //Read more about FluentAssertions: https://fluentassertions.com/
            capacity.Should().BeGreaterThan(0); 

            var result = await _groupsApiClient.CreateGroup(new GroupRequest
            {
                Name = "Test group",
                Amps = capacity
            });

            result.Should().NotBeNull();
            result.Amps.Should().Be(capacity);

            _groupContext.CurrentGroupId = result.Id;
        }

        [When(@"capacity of the group changed to (\d+) A")]
        public async Task WhenCapacityOfTheGroupChangedToA(int capacity)
        {
            capacity.Should().BeGreaterThan(0);
            _groupContext.CurrentGroupId.Should().NotBeNull("A group should be created before the step");

            await _groupsApiClient.UpdateGroup(_groupContext.CurrentGroupId!.Value, new GroupRequest
            {
                Amps = capacity,
                Name = "Test group",
            });
        }

        [Then(@"the group has capacity (\d+) A")]
        public async Task ThenTheGroupHasCapacityA(int capacity)
        {
            capacity.Should().BeGreaterThan(0);
            _groupContext.CurrentGroupId.Should().NotBeNull("A group should be created before the step");

            var result = await _groupsApiClient.GetGroup(_groupContext.CurrentGroupId!.Value);

            result.Should().NotBeNull();
            result.Amps.Should().Be(capacity);
        }
    }
}
