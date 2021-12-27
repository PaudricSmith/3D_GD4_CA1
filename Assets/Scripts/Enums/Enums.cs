
    /// <summary>
    /// Used in a ScriptableObject to indicate the type of the item about which the SO is storing information
    /// </summary>
    /// 
    public enum ItemType : sbyte
    {
        Building, Equipment, Food, Medicine, NPC, Player, Story
    }


    /// <summary>
    /// Used to indicate priority (e.g. completion of objectives)
    /// </summary>
    /// 
    public enum PriorityType : sbyte
    {
        //assigning explicit values here allows us to sort whatever entity (e.g. GameObjective) use this type
        Low = 0, Normal = 1, High = 2, Critical = 3
    }


    /// <summary>
    /// Used to specify if an onscreen object (e.g. a waypoint) is always shown
    /// </summary>
    /// 
    public enum VisibilityStrategyType : sbyte
    {
        ShowAlways, ShowWithin, ShowNever
    }