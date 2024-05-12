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
    public class GetData : IGetData
    {
        IServiceScopeFactory _serviceScopeFactory;

        // Constructor to initialize GetData with IServiceScopeFactory.
        public GetData(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        // Method to asynchronously retrieve ticket overview data from the database.
        public async Task<List<TicketOverviewViewModel>> GetTicketOverviewAsync()
        {
            // Creating a scope to resolve DbContext dependency.
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CJDBContext>();

                // Query to join ticket data with related entities and project into a view model.
                var query = from t in dbContext.Tickets
                            join b in dbContext.Brugeres on t.BrugerId equals b.BrugerId
                            join s in dbContext.Brugeres on t.SupporterId equals s.BrugerId
                            join st in dbContext.Statuses on t.StatusId equals st.StatusId
                            join p in dbContext.Prioriteters on t.PrioritetId equals p.PrioritetId
                            join k in dbContext.Kategoriers on t.KategoriId equals k.KategoriId
                            select new TicketOverviewViewModel
                            {
                                TicketID = t.TicketId,
                                Oprettelsestid = t.Oprettelsestid,
                                Titel = t.Titel,
                                Beskrivelse = t.Beskrivelse,
                                BrugerFNavn = b.Fornavn,
                                BrugerLNavn = b.Efternavn,
                                BrugerEmail = b.Email,
                                SupportFNavn = s.Fornavn,
                                SupportLNavn = s.Efternavn,
                                StatusNavn = st.Navn,
                                PrioritetNavn = p.Navn,
                                KategoriNavn = k.Navn
                                //Titel = t.Titel,
                                //Beskrivelse = t.Beskrivelse,
                                //BrugerId = t.BrugerId,
                                //SupporterId = t.SupporterId
                            };
                List<TicketOverviewViewModel> result = await query.ToListAsync();
                return result;
            }
        }

        // Method to asynchronously retrieve ticket data by ticket ID from the database.
        public async Task<List<TicketViewModel>> GetTicketAsync(int ticketid)
        {
            // Creating a scope to resolve DbContext dependency.
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CJDBContext>();

                // Retrieving KatPrioStaViewModel.
                KatPrioStaViewModel kps = await GetKatPrioStaAsync();

                // Query to join ticket data with related entities and project into a view model.
                var query = from t in dbContext.Tickets
                            join st in dbContext.Statuses on t.StatusId equals st.StatusId
                            join p in dbContext.Prioriteters on t.PrioritetId equals p.PrioritetId
                            join k in dbContext.Kategoriers on t.KategoriId equals k.KategoriId
                            where t.TicketId == ticketid
                            select new TicketViewModel
                            {
                                TicketID = t.TicketId,
                                Oprettelsestid = t.Oprettelsestid,
                                Titel = t.Titel,
                                Beskrivelse = t.Beskrivelse,
                                StatusNavn = st.Navn,
                                PrioritetNavn = p.Navn,
                                KategoriNavn = k.Navn,
                                //Titel = t.Titel,
                                //Beskrivelse = t.Beskrivelse,
                                //BrugerId = t.BrugerId,
                                //SupporterId = t.SupporterId
                                KatPrioStat = kps
                            };
                List<TicketViewModel> result = await query.ToListAsync();
                return result;
            }
        }

        // Method to asynchronously retrieve KatPrioStaViewModel data from the database.
        public async Task<KatPrioStaViewModel> GetKatPrioStaAsync()
        {
            // Creating a scope to resolve DbContext dependency.
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CJDBContext>();

                // Query to retrieve Kategorier data.
                var queryKat = from k in dbContext.Kategoriers
                               select new Kategorier
                               {
                                   KategoriId = k.KategoriId,
                                   Navn = k.Navn,
                               };
                List<Kategorier> Kat = await queryKat.ToListAsync();

                // Query to retrieve Prioriteter data.
                var queryPrio = from p in dbContext.Prioriteters
                                select new Prioriteter
                                {
                                    PrioritetId = p.PrioritetId,
                                    Navn = p.Navn,
                                };
                List<Prioriteter> Prio = await queryPrio.ToListAsync();

                // Query to retrieve Status data.
                var querySta = from s in dbContext.Statuses
                               select new Status
                               {
                                   StatusId = s.StatusId,
                                   Navn = s.Navn,
                               };
                List<Status> Sta = await querySta.ToListAsync();

                // Creating KatPrioStaViewModel object with retrieved data.
                var result = new KatPrioStaViewModel
                {
                    Kategori = Kat,
                    Prioritet = Prio,
                    Status = Sta
                };
                return result;
            }
        }
    }
}
