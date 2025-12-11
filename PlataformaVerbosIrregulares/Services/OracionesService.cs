using Microsoft.EntityFrameworkCore;
using PlataformaVerbosIrregulares.Models.DTOs;
using PlataformaVerbosIrregulares.Models.Entities;
using PlataformaVerbosIrregulares.Repositories;

namespace PlataformaVerbosIrregulares.Services
{
    public class OracionesService
    {
        public OracionesService(Repository<Oraciones> oracionesRepository)
        {
            OracionesRepository=oracionesRepository;
        }

        public Repository<Oraciones> OracionesRepository { get; }

  

        public IEnumerable<OracionDTO> GetOracionesByCantidad(int cant)
        {
            return OracionesRepository.GetAll().AsQueryable().OrderBy(x => EF.Functions.Random()).Select(x => new OracionDTO
            {
                id=x.Id,
                Descripcion=x.Descripcion,
                VerboBase=x.VerboBase,
                VerboTiempoAdecudado=x.VerboCorrecto
            }).Take(cant).ToList();
        }
    }
}
