namespace Warlords.Battle.Field
{
    public interface IActionDispatcher
    {
        ActionDispatchService DispatchService { get; set; }
    }
}