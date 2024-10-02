using System.Linq;
using System.Text.RegularExpressions;

public static class Validador
{
    public static bool ValidarCPF(string cpf)
    {
        // Remover caracteres não numéricos
        cpf = Regex.Replace(cpf, @"\D", "");

        // CPF deve ter 11 dígitos
        if (cpf.Length != 11 || new[] { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" }.Contains(cpf))
            return false;

        // Validação dos dígitos verificadores
        var soma = 0;
        var resto = 0;

        for (var i = 1; i <= 9; i++)
            soma += int.Parse(cpf[i - 1].ToString()) * (11 - i);

        resto = (soma * 10) % 11;

        if (resto == 10 || resto == 11)
            resto = 0;

        if (resto != int.Parse(cpf[9].ToString()))
            return false;

        soma = 0;

        for (var i = 1; i <= 10; i++)
            soma += int.Parse(cpf[i - 1].ToString()) * (12 - i);

        resto = (soma * 10) % 11;

        if (resto == 10 || resto == 11)
            resto = 0;

        return resto == int.Parse(cpf[10].ToString());
    }
}
