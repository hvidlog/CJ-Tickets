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

        // Constructor to initialize AddData with IServiceScopeFactory.
        public AddData(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        // Method to asynchronously add a new ticket to the database.
        public async Task AddTicketAsync(TicketCreateViewModel model)
        {
            // Creating a scope to resolve DbContext dependency.
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CJDBContext>();
                var newTicket = new Ticket
                {
                    Titel = model.Titel,
                    Beskrivelse = model.Beskrivelse,
                    BrugerId = 3,    // 
                    SupporterId = 4, // These numbers are hardcoded in here for demonstration purposes
                    StatusId = 1,    //
                    PrioritetId = model.PrioritetId,
                    KategoriId = model.KategoriId
                };

                // Add the new ticket to the database.
                dbContext.Tickets.Add(newTicket);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}