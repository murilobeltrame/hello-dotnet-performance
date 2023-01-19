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
            _context.Database.EnsureCreated();

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
                kisi);
            _context.SaveChanges();
        }
	}
}
