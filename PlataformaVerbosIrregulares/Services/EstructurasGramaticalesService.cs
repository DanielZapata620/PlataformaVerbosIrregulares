using Microsoft.EntityFrameworkCore;
using PlataformaVerbosIrregulares.Models.DTOs;
using PlataformaVerbosIrregulares.Models.Entities;
using PlataformaVerbosIrregulares.Repositories;

namespace PlataformaVerbosIrregulares.Services
{
    public class EstructurasGramaticalesService
    {
        public EstructurasGramaticalesService(Repository<Estructuras> estructurasRepository, Repository<Reglas> reglasRepository)
        {
            EstructurasRepository=estructurasRepository;
            ReglasRepository=reglasRepository;
        }

        public Repository<Estructuras> EstructurasRepository { get; }
        public Repository<Reglas> ReglasRepository { get; }

        public EstructurasDTO GetEstructuraConReglas(string TiempoGramatical)
        {
            EstructurasDTO e = new();
            e.Estructuras= EstructurasRepository.GetAll().Where(x => x.Tiempo.ToLower()==TiempoGramatical.ToLower())
                .Select(x => new EstructuraDTO
                {
                    Sujeto=x.Sujeto,
                    Auxiliar=x.Auxiliar,
                    Verbo=x.Verbo,
                    Complemento=x.Complemento,
                    Modo=x.Modo,
                    Tiempo=x.Tiempo,
                    Tipo=x.Tipo
                });
            e.Reglas=ReglasRepository.GetAll().AsQueryable().Include(x=>x.IdEstructuraNavigation)
                                     .Where(x => x.IdEstructuraNavigation.Tiempo==TiempoGramatical)
                                     .Select(x => new ReglaDTO
                                     {
                                          CambioEn=x.CambioEn,
                                          Descripcion=x.Descripcion,
                                          Tipo=x.IdEstructuraNavigation.Tipo,
                                          Modo=x.IdEstructuraNavigation.Modo
                                     }).ToList();


            return e;
        }
    }
}
