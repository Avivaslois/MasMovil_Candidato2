using Catalog.Domain.DTO;
using Catalog.Infrastructure.DTO;
using Catalog.Infrastructure.DTO.Mappers;
using Catalog.Infrastructure.Factories;
using Catalog.Infrastructure.Models;
using Catalog.Infrastructure.Models.Catalog.Infrastructure.Models;
using Catalog.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Domain.ControllerWorkers
{
    public class PhoneControllerWorker: IPhoneCW
    {
        private UnitOfWork<Context> UnitOfWork = new UnitOfWork<Context>(new PhoneContextFactory());
        private readonly IRepository<Phone> Repository;

        public PhoneControllerWorker()
        {
            Repository = UnitOfWork.GetRepository<Phone>();
        }

        public PhoneControllerWorker(IRepository<Phone> mockRepository)
        {
            Repository = mockRepository;
        }

        public List<PhoneDto> obtenerTelefonos()
        {
            try
            {
                List<PhoneDto> resultado;

                resultado = Repository.FindAll().Select(x => DTOMapper.Phone_To_PhoneDto(x)).ToList();

                return resultado;
            }
            catch (Exception excepcion)
            { 
                throw excepcion;
            }
        }

        public List<PhonePriceDto> obtenerPrecioPorId(List<int> ids)
        {
            try
            {
                List<PhonePriceDto> data = Repository.FindAll(x => ids.Any(y => y == x.Id))
                                                                 .Select(z => new PhonePriceDto { PhoneId= z.Id, PhonePrice= z.Price }).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PhoneDto obtenerTelefonoPorId(int PhoneId)
        {
            try
            {
                PhoneDto result = null;
                var data = Repository.FindById(PhoneId);
                if (data != null) { result = DTOMapper.Phone_To_PhoneDto(data); }
                return result;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }
    }
}
