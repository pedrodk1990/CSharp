using System;

public class RegistroPonto
{
    public Usuario Usuario { get; set; } // Armazena a instância do usuário
    public DateTime Data { get; set; }
    public DateTime? Entrada { get; set; }
    public DateTime? Saida { get; set; }
    public TimeSpan? HorasTrabalhadas => Saida.HasValue && Entrada.HasValue ? Saida.Value - Entrada.Value : (TimeSpan?)null;
}