using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public static class JsonStorage
{
    private const string FilePath = "registros.json";

    public static List<RegistroPonto> Load()
    {
        if (!File.Exists(FilePath))
            return new List<RegistroPonto>();

        var json = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<RegistroPonto>>(json) ?? new List<RegistroPonto>();
    }

    public static void Save(List<RegistroPonto> registros)
    {
        var json = JsonConvert.SerializeObject(registros, Formatting.Indented);
        File.WriteAllText(FilePath, json);
    }
}
