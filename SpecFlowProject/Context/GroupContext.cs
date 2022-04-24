namespace SpecFlowProject.Context
{
    /// <summary>
    /// The context to store group related stuff
    /// Read more about ScenarioContext: https://docs.specflow.org/projects/specflow/en/latest/Bindings/ScenarioContext.html
    /// </summary>
    public class GroupContext
    {
        private const string CurrentGroupIdKey = "CurrentGroupId";
        private readonly ScenarioContext _scenarioContext;

        public GroupContext(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public Guid? CurrentGroupId
        {
            set => _scenarioContext.Set(value, CurrentGroupIdKey);
            get => _scenarioContext.GetValueOrDefault(CurrentGroupIdKey, null) as Guid?;
        }
    }
}
