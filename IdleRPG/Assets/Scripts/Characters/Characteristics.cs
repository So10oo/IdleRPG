public class Characteristics
{
    public Stat Armor { get; private set; } = new();
    public ExhaustibleStat Health { get; private set; } = new();
    public Stat AttackPower { get; private set; } = new();
    public Stat AttackTime { get; private set; } = new();
    public Stat PreparationTime { get; private set; } = new();

    public Characteristics(CharacteristicsData characteristicsData) : base()
    {
        Armor.SetBaseModified(new Modifier(characteristicsData.armor));
        Health.SetBaseModified(new Modifier(characteristicsData.health));
        AttackPower.SetBaseModified(new Modifier(characteristicsData.attackPower));
        AttackTime.SetBaseModified(new Modifier(1000));
        PreparationTime.SetBaseModified(new Modifier(characteristicsData.preparationTime_ms));
    }
}

