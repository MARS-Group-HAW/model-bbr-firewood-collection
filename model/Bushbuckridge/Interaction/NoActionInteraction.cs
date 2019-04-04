using Mars.Interfaces.Agent;

namespace Bushbuckridge.Agents
{
    public class NoActionInteraction : IInteraction
    {
        public static readonly IInteraction Get = new NoActionInteraction();
        
        public void Execute()
        {
            //do nothing
        }
    }
}