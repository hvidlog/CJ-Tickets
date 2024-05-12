using Microsoft.EntityFrameworkCore;
using CJ.Data;
using CJ.Models;
using CJ.Repository.Interfaces;

// --- NOT IN USE ---

namespace CJ.Repository
{
    public class UpdateData : IUpdateData
    {
        IServiceScopeFactory _serviceScopeFactory;

        // Constructor to initialize UpdateData with IServiceScopeFactory.
        public UpdateData(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        // Method to asynchronously update a ticket in the database.
        public async Task UpdateTicketAsync(Ticket ticket)
        {
            // Creating a scope to resolve DbContext dependency.
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CJDBContext>();

                // Retrieving the existing ticket from the database.
                var existingTicket = await dbContext.Tickets.FirstOrDefaultAsync(a => a.TicketId == ticket.TicketId);
                if (existingTicket != null)
                {
                    // Updating the existing ticket with new values.
                    dbContext.Entry(existingTicket).CurrentValues.SetValues(ticket);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
