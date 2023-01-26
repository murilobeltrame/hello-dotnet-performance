using Microsoft.EntityFrameworkCore;
using Wineyard.Models;

namespace Wineyard.Tools
{
    public class DbInitializer
    {
        private readonly ApplicationContext _context;

        public DbInitializer(ApplicationContext context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();

            var petitVerdot = new Grape("Petit Verdot");
            var shiraz = new Grape("Shiraz");
            var merlot = new Grape("Merlot");
            var negroamaro = new Grape("Negroamaro");
            var malvasiaNera = new Grape("Malvasia Nera");
            var primitivo = new Grape("Primitivo");
            var sangiovese = new Grape("Sangiovese");
            var cabernetSalvignon = new Grape("Cabernet Sauvignon");
            var xinomavro = new Grape("Xinomavro");
            var marselan = new Grape("Marselan");
            var pinotNoir = new Grape("Pinot Noir");
            var cabernetFranc = new Grape("Cabernet Franc");
            var pinotage = new Grape("Pinotage");
            var cinsaut = new Grape("Cinsaut");
            var moscatel = new Grape("Moscatel");
            var malbec = new Grape("Malbec");
            var ancellotta = new Grape("Ancellotta");
            var carmenere = new Grape("Carmenère");
            var tempranillo = new Grape("Tempranillo");
            var kisi = new Grape("Kisi");
            var barbera = new Grape("Barbera");
            var dolcetto = new Grape("Dolcetto");
            var bonarda = new Grape("Bonarda");
            var freisa = new Grape("Freisa");
            var albarossa = new Grape("Albarossa");
            var chardonnay = new Grape("Chardonnay");
            var petitSirah = new Grape("Petit Sirah");
            var alicanteBouschet = new Grape("Alicante Bouschet");
            var aragonez = new Grape("Aragonez");
            var castelao = new Grape("Castelão");
            var tannat = new Grape("Tannat");
            var saperavi = new Grape("Saperavi");
            var dornfelder = new Grape("Dornfelder");
            var grenache = new Grape("Grenache");
            var carignan = new Grape("Carignan");
            var pinotGrigio = new Grape("Pinot Grigio");
            var bobal = new Grape("Bobal");
            var cinsault = new Grape("Cinsault");
            var trincadeira = new Grape("Trincadeira");
            var tourigaNacional = new Grape("Touriga Nacional");
            var melnik = new Grape("Melnik");
            var arintoBucelas = new Grape("Arinto de Bucelas");
            var loureiro = new Grape("Loureiro");
            var fernaoPires = new Grape("Fernão Pires");
            var riesling = new Grape("Riesling");
            var mourvedre = new Grape("Mourvedre");

            _context.Grapes.AddRange(
                petitVerdot,
                shiraz,
                merlot,
                negroamaro,
                malvasiaNera,
                primitivo,
                sangiovese,
                cabernetSalvignon,
                xinomavro,
                marselan,
                pinotNoir,
                cabernetFranc,
                pinotage,
                cinsaut,
                moscatel,
                malbec,
                ancellotta,
                carmenere,
                tempranillo,
                kisi,
                barbera,
                dolcetto,
                bonarda,
                freisa,
                albarossa,
                chardonnay,
                petitSirah,
                alicanteBouschet,
                aragonez,
                castelao,
                tannat,
                saperavi,
                dornfelder,
                grenache,
                carignan,
                pinotGrigio,
                bobal,
                cinsault,
                trincadeira,
                tourigaNacional,
                melnik,
                arintoBucelas,
                loureiro,
                fernaoPires,
                riesling,
                mourvedre);

            var periquita = new Wine("José Maria da Fonseca", "Periquita Tinto", "Portugal", 2016);
            var reservado = new Wine("Santa Carolina", "Reservado Cabernet Sauvignon", "Chile", 2013);
            var premiumTannat = new Wine("Ravanello", "Premium Tannat", "Brasil", 2013);
            var garibaldiMoscatel = new Wine("Garibaldi", "Moscatel", "Brasil", 2018);
            var trapiche = new Wine("Trapiche", "Vineyards Malbec", "Argentina", 2017);
            var terreDeMistral = new Wine("Rémy Ferbras", "Terre de Mistral Gigondas Rouge", "França", 2015);
            var niepoort = new Wine("Niepoort", "Touriga Nacional", "Portugal", 2015);

            _context.Wines.AddRange(
                periquita,
                reservado,
                premiumTannat,
                garibaldiMoscatel,
                trapiche,
                terreDeMistral,
                niepoort);

            // _context.WineGrapes.Add(new WineGrape { Wine = periquita, Grape = aragonez });
            // _context.WineGrapes.Add(new WineGrape { Wine = periquita, Grape = castelao });
            // _context.WineGrapes.Add(new WineGrape { Wine = periquita, Grape = trincadeira });
            // _context.WineGrapes.Add(new WineGrape { Wine = reservado, Grape = cabernetSalvignon });
            // _context.WineGrapes.Add(new WineGrape { Wine = premiumTannat, Grape = tannat });
            // _context.WineGrapes.Add(new WineGrape { Wine = garibaldiMoscatel, Grape = moscatel });
            // _context.WineGrapes.Add(new WineGrape { Wine = trapiche, Grape = malbec });
            // _context.WineGrapes.Add(new WineGrape { Wine = terreDeMistral, Grape = grenache });
            // _context.WineGrapes.Add(new WineGrape { Wine = terreDeMistral, Grape = shiraz });
            // _context.WineGrapes.Add(new WineGrape { Wine = terreDeMistral, Grape = mourvedre });
            // _context.WineGrapes.Add(new WineGrape { Wine = niepoort, Grape = tourigaNacional });

            _context.SaveChanges();
        }
    }
}
