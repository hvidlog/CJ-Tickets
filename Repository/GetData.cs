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

        public async Task<List<TicketOverviewViewModel>> GetTicketOverviewAsync()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CJDBContext>();

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

        public async Task<List<TicketViewModel>> GetTicketAsync(int ticketid)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            { 
                var dbContext = scope.ServiceProvider.GetRequiredService<CJDBContext>();

                //List<string> muligeKats = await (from k in dbContext.Kategoriers select k.Navn).ToListAsync();
                KatPrioStaViewModel kps = await GetKatPrioStaAsync();

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
        public async Task<KatPrioStaViewModel> GetKatPrioStaAsync()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CJDBContext>();

                var queryKat = from k in dbContext.Kategoriers
                               select new Kategorier
                               {
                                   KategoriId = k.KategoriId,
                                   Navn = k.Navn,
                               };
                List<Kategorier> Kat = await queryKat.ToListAsync();

                var queryPrio = from p in dbContext.Prioriteters
                               select new Prioriteter
                               {
                                   PrioritetId = p.PrioritetId,
                                   Navn = p.Navn,
                               };
                List<Prioriteter> Prio = await queryPrio.ToListAsync();

                var querySta = from s in dbContext.Statuses
                               select new Status
                               {
                                   StatusId = s.StatusId,
                                   Navn = s.Navn,
                               };
                List<Status> Sta = await querySta.ToListAsync();

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
