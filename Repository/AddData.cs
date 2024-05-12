using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CJ.Data;
using CJ.Models;
//using CJ.Models.TicketData;
using CJ.Repository.Interfaces;
using CJ.ViewModels;
using static System.Formats.Asn1.AsnWriter;

namespace CJ.Repository
{
    public class AddData : IAddData
    {
        IServiceScopeFactory _serviceScopeFactory;

        public AddData(IServiceScopeFactory serviceScopeFactory) 
        {
            _serviceScopeFactory= serviceScopeFactory;
        }

        public async Task AddTicketAsync(TicketCreateViewModel model)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CJDBContext>();
                var newTicket = new Ticket
                {
                    Titel = model.Titel,
                    Beskrivelse = model.Beskrivelse,
                    BrugerId = 3,  
                    SupporterId = 4,
                    StatusId = 1, 
                    PrioritetId = model.PrioritetId, 
                    KategoriId = model.KategoriId 
                };

                // Tilføj den nye ticket til databasen
                dbContext.Tickets.Add(newTicket);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
