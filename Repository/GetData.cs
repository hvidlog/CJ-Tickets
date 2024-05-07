using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ZBC.Data;
using ZBC.Models;
//using ZBC.Models.TicketData;
using ZBC.Repository.Interfaces;
using ZBC.ViewModels;
using static System.Formats.Asn1.AsnWriter;

namespace ZBC.Repository
{
    public class GetData : IGetData
    {
        IServiceScopeFactory _serviceScopeFactory;

        public GetData(IServiceScopeFactory serviceScopeFactory) 
        {
            _serviceScopeFactory= serviceScopeFactory;
        }

        public async Task<List<TicketOverviewViewModel>> GetTicketAsync()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CJDBContext>();

                var query = from t in dbContext.Tickets
                            select new TicketOverviewViewModel
                            {
                                TicketID = t.TicketId,
                                Titel = t.Titel
                            };
                List<TicketOverviewViewModel> result = await query.ToListAsync();
                return result;
            }
        }
    }
}
