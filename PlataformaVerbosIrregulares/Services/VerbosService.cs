using Microsoft.EntityFrameworkCore;
using PlataformaVerbosIrregulares.Models.DTOs;
using PlataformaVerbosIrregulares.Models.Entities;
using PlataformaVerbosIrregulares.Repositories;

namespace PlataformaVerbosIrregulares.Services
{
    public class VerbosService
    {
        public VerbosService(Repository<Verbosirregulares> verbosRepository)
        {
            VerbosRepository=verbosRepository;
        }

        public Repository<Verbosirregulares> VerbosRepository { get; }

        public IEnumerable<VerboDTO> GetAllVerbos()
        {
            return VerbosRepository.GetAll().Select(x=> new VerboDTO 
            {
                Presente=x.BaseForm,
                Pasado=x.Past,
                Participio=x.Participle,
                Espanol=x.Espanol,  
            });
        }

        public IEnumerable<VerboDTO> GetVerbosByCantidad(int cant)
        {
            return VerbosRepository.GetAll().AsQueryable().OrderBy(x => EF.Functions.Random()).Select(x => new VerboDTO
            {
                Presente=x.BaseForm,
                Pasado=x.Past,
                Participio=x.Participle,
                Espanol=x.Espanol,
            }).Take(cant).ToList();
        }
    }
}
