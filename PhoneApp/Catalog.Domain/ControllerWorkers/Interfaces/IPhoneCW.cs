using Catalog.Domain.DTO;
using Catalog.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.ControllerWorkers
{
    public interface IPhoneCW 
    {
        List<PhoneDto> obtenerTelefonos();

        PhoneDto obtenerTelefonoPorId(int id);

        List<PhonePriceDto> obtenerPrecioPorId(List<int> ids);
    }
}
