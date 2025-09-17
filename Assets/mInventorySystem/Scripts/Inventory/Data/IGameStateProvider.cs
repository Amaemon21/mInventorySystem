namespace Inventory
{
    public interface IGameStateProvider : IGameStateSaver
    {
        public void Load();
    }
}