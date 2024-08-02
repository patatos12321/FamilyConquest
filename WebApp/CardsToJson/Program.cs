// See https://aka.ms/new-console-template for more information
using FamilyConquest.Common.Models.Cards;
using System.Text.Json;

Console.WriteLine("Hello, World!");

string path = "C:\\Users\\patat\\source\\repos\\FamilyConquest\\WebApp\\FamilyConquest.Common\\Models\\Cards";

string json = JsonSerializer.Serialize(new Brutus(), GetSerializationOption());
File.WriteAllText($"{Path.Combine(path, nameof(Brutus))}.json", json);

json = JsonSerializer.Serialize(new Doby(), GetSerializationOption());
File.WriteAllText($"{Path.Combine(path, nameof(Doby))}.json", json);

json = JsonSerializer.Serialize(new Peanut(), GetSerializationOption());
File.WriteAllText($"{Path.Combine(path, nameof(Peanut))}.json", json);

json = JsonSerializer.Serialize(new Rat(), GetSerializationOption());
File.WriteAllText($"{Path.Combine(path, nameof(Rat))}.json", json);

json = JsonSerializer.Serialize(new Shirley(), GetSerializationOption());
File.WriteAllText($"{Path.Combine(path, nameof(Shirley))}.json", json);

json = JsonSerializer.Serialize(new ThorSniper(), GetSerializationOption());
File.WriteAllText($"{Path.Combine(path, nameof(ThorSniper))}.json", json);

static JsonSerializerOptions GetSerializationOption()
{
    Cache.JsonSerializerOptions ??= new JsonSerializerOptions { WriteIndented = true };
    return Cache.JsonSerializerOptions;
}

public class Cache
{
    public static JsonSerializerOptions? JsonSerializerOptions { get; set; }
}