using Microsoft.EntityFrameworkCore;
using ZBC.Data;
using ZBC.Models;
using ZBC.Repository.Interfaces;

namespace ZBC.Repository
{
    public class UpdateData : IUpdateData
    {
        IServiceScopeFactory _serviceScopeFactory;
        public UpdateData(IServiceScopeFactory serviceScopeFactory) 
        {
            _serviceScopeFactory= serviceScopeFactory;
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CJDBContext>();

                var existingTicket = await dbContext.Tickets.FirstOrDefaultAsync(a => a.TicketId == ticket.TicketId);
                if (existingTicket != null)
                {
                    dbContext.Entry(existingTicket).CurrentValues.SetValues(ticket);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
