using System.Collections.Generic;

public class Fruit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string Order { get; set; }
    public string Genus { get; set; }
    public string Nutritions { get; set; }
    public List<FruitMetadata> Metadata { get; set; } = new List<FruitMetadata>();
    public object NutritionFacts { get; internal set; }
}
public class FruitMetadata
{
    public int Id { get; set; }
    public int FruitId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}