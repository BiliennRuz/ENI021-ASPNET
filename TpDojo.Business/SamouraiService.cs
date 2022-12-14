namespace TpDojo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.Business.Dto;
using TpDojo.Dal.Abstractions;

public class SamouraiService
{
    private readonly ISamouraiAccessLayer samouraiAccessLayer;
    private readonly IArmeAccessLayer armeAccessLayer;

    public SamouraiService(ISamouraiAccessLayer samouraiAccessLayer, IArmeAccessLayer armeAccessLayer)
    {
        this.samouraiAccessLayer = samouraiAccessLayer;
        this.armeAccessLayer = armeAccessLayer;
    }

    public async Task<List<SamouraiDto>> GetSamouraisAsync()
    {
        var samourais = await this.samouraiAccessLayer.GetAllAsync();
        return SamouraiDto.FromSamourais(samourais);
    }

    public async Task<bool> SamouraiExistsAsync(int id)
        => await this.samouraiAccessLayer.ExistsAsync(id);

    public async Task<SamouraiDto> GetSamouraiByIdAsync(int? id)
    {
        var arme = await this.samouraiAccessLayer.GetByIdAsync(id);
        return SamouraiDto.FromSamourai(arme);
    }

    public async Task AddSamouraiAsync(SamouraiDto samouraiDto, int armId)
    {
        var samourai = SamouraiDto.ToSamourai(samouraiDto);
        var arme = await this.armeAccessLayer.GetByIdAsync(armId);
        samourai.Arme = arme;

        await this.samouraiAccessLayer.AddAsync(samourai);
    }

    public async Task UpdateSamouraiAsync(SamouraiDto armeDto)
    {
        var arme = SamouraiDto.ToSamourai(armeDto);
        await this.samouraiAccessLayer.UpdateAsync(arme);
    }

    public async Task RemoveSamouraiAsync(int id)
    {
        await this.samouraiAccessLayer.RemoveAsync(id);
    }

}
