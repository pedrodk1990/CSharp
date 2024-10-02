using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public static class UserStorage
{
    private const string UserFilePath = "usuarios.json";

    public static List<Usuario> LoadUsers()
    {
        if (!File.Exists(UserFilePath))
            return new List<Usuario>();

        var json = File.ReadAllText(UserFilePath);
        return JsonConvert.DeserializeObject<List<Usuario>>(json) ?? new List<Usuario>();
    }

    public static void SaveUsers(List<Usuario> usuarios)
    {
        var json = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
        File.WriteAllText(UserFilePath, json);
    }
}
