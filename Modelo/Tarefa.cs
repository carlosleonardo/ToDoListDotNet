using System.ComponentModel.DataAnnotations;

public class Tarefa {

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome deve ser informado"), 
        StringLength(40, MinimumLength = 6, ErrorMessage = "Tamanho mínimo de 6")]
    public string? Nome { get; set; }
    [StringLength(100, ErrorMessage = "Descrição muito longa. Limite-a a 100 caracteres")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "Data de início deve ser informada")]
    public DateTime DataInicio { get; set; }
    public DateTime? DataTermino { get; set; }
    [Required(ErrorMessage = "Informe se está finalizada")]
    public bool Finalizada { get; set; }
}