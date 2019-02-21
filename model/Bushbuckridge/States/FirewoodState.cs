using Mars.Components.Services.Planning.Worldstate;

namespace Bushbuckridge.States
{
    public static class FirewoodState
    {
        public static readonly GoapStateKey<bool> HasEnoughFirewood = new GoapStateKey<bool>("HasEnoughFirewood");
        public static readonly GoapStateKey<bool> AtExploitablePosition = new GoapStateKey<bool>("AtExploitablePosition");
        public static readonly GoapStateKey<bool> IsNearDeadwoodTree = new GoapStateKey<bool>("IsNearDeadwoodTree");
        public static readonly GoapStateKey<bool> IsNearAlivewoodTree = new GoapStateKey<bool>("IsNearAlivewoodTree");
//        public static readonly GoapStateKey<bool> IsShootAvailable = new GoapStateKey<bool>("IsShootAvailable");
        public static readonly GoapStateKey<bool> Orientated = new GoapStateKey<bool>("Orientated");
        public static readonly GoapStateKey<bool> Home = new GoapStateKey<bool>("Home");
        public static readonly GoapStateKey<bool> WoodstockRaised = new GoapStateKey<bool>("WoodstockRaised");
        public static readonly GoapStateKey<bool> HasAxe = new GoapStateKey<bool>("HasAxe");
        public static readonly GoapStateKey<bool> TimeIsUp = new GoapStateKey<bool>("TimeIsUp");
        public static readonly GoapStateKey<bool> Evaluated = new GoapStateKey<bool>("Evaluated");
    }
}