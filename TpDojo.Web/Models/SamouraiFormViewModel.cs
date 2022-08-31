namespace TpDojo.Web.Models;

using TpDojo.Business.Dto;

public class SamouraiFormViewModel
{
    public int Id { get; set; }
    public int Force { get; set; }
    public string Nom { get; set; }
    public int ArmeId { get; set; }

    public string NomDisplay => $"{this.Nom} (PF: {this.Force})";

    internal static SamouraiFormViewModel FromSamouraiDto(SamouraiDto? samourai)
    => samourai is null
    ? new()
    : new SamouraiFormViewModel { Id = samourai.Id, Nom = samourai.Nom, Force = samourai.Force };

    internal static List<SamouraiFormViewModel> FromSamourais(List<SamouraiDto> samouraiDtos)
        => samouraiDtos.Select(FromSamouraiDto).ToList();

    internal static SamouraiDto ToSamouraiDto(SamouraiFormViewModel samouraiViewModel)
        => new() { Id = samouraiViewModel.Id, Nom = samouraiViewModel.Nom, Force = samouraiViewModel.Force };

}
