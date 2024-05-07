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
                    BrugerId = 3,  // Antager at BrugerId kommer fra et sted (session, model, etc.)
                    SupporterId = 4,  // Dette skal også håndteres afhængigt af applikationens logik
                    StatusId = 1,  // For eksempel, antager en initial status, skal håndteres korrekt
                    PrioritetId = model.PrioritetId,  // Konverteret fra model.Prioritet til en ID
                    KategoriId = model.KategoriId  // Konverteret fra model.Kategori til en ID
                };

                // Tilføj den nye ticket til databasen
                dbContext.Tickets.Add(newTicket);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
