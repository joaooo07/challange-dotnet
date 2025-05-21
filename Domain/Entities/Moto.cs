using System.ComponentModel.DataAnnotations.Schema;

[Table("MOTOS")]
public class Moto
{
    [Column("ID")]
    public int Id { get; set; }

    [Column("MARCA")]
    public string Marca { get; set; } = string.Empty;

    [Column("MODELO")]
    public string Modelo { get; set; } = string.Empty;

    [Column("ANO")]
    public int Ano { get; set; }

    [Column("PLACA")]
    public string Placa { get; set; } = string.Empty;
}
