using System;
using CarService.Common.ModelDto;

namespace CarService.BusinessLogic.Services
{
    public interface IPurchaseHistoryService
    {
        bool SyncDetail(int detailId);
        bool SyncCar(int detailId);
        List<PurchaseHistoryDto> Get();
        bool Delete(int Id);
    }
}

