using System.Text.Json.Serialization;

public class FieldModel
{
    public List<List<int?>> Field { get; set; }

    public FieldModel(List<List<int?>> field)
    {
        Field = field;
    }

    [JsonConstructor]
    public FieldModel()
    {
        Field = Enumerable.Repeat<List<int?>>(Enumerable.Repeat<int?>(null, FieldSize.y).ToList(), FieldSize.x).ToList();
    }

}