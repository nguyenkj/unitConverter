using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using unitConverter.Models;

namespace unitConverter
{
    public class UselessThingDatabase
    {
        readonly SQLiteAsyncConnection DatabaseHelper; 

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
        });

        //static SQLiteAsyncConnection Database => lazyInitializer.Value;
        //static bool initialized = false;

        public UselessThingDatabase(string dbPath)
        {
            DatabaseHelper = new SQLiteAsyncConnection(dbPath);
            DatabaseHelper.DropTableAsync<UselessThing>().Wait();
            DatabaseHelper.CreateTableAsync<UselessThing>().Wait();
        }

        //async Task InitializeAsync()
        //{
        //    if (!initialized)
        //    {
        //        if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(UselessThing).Name))
        //        {
        //            await Database.CreateTablesAsync(CreateFlags.None, typeof(UselessThing)).ConfigureAwait(false);
        //        }
        //        initialized = true;
        //    }
        //}

        public UselessThing AddUselessThing(string name, string type, float weight, float length)
        {
            UselessThing thisThing = new UselessThing();

            thisThing.Name = name;
            thisThing.Type = type;
            thisThing.Weight = weight;
            thisThing.Length = length;

            return thisThing;
        }

        public void FillUselessThingTable()
        {            
            UselessThing HondaCivic = AddUselessThing("1995 Honda Civic", "Vehicle", (float)1143, (float)4.069);
            App.Database.SaveUselessThingAsync(HondaCivic);

            UselessThing LancerEvo = AddUselessThing("1999 Mitsubishi Lancer Evo VI", "Vehicle", (float)1260, (float)4.350);
            App.Database.SaveUselessThingAsync(LancerEvo);

            UselessThing TeslaModel3 = AddUselessThing("2017 Tesla Model 3", "Vehicle", (float)1611, (float)4.694);
            App.Database.SaveUselessThingAsync(TeslaModel3);

            UselessThing KevinBacon = AddUselessThing("Kevin Bacon", "People", (float)76, (float)1.78);
            App.Database.SaveUselessThingAsync(KevinBacon);

            UselessThing ElonMusk = AddUselessThing("Elon Musk", "People", (float)93, (float)1.88);
            App.Database.SaveUselessThingAsync(ElonMusk);

            UselessThing KanyeWest = AddUselessThing("Kanye West", "People", (float)84, (float)1.73);
            App.Database.SaveUselessThingAsync(KanyeWest);

            UselessThing DonaldTrump = AddUselessThing("Donald Trump", "People", (float)110, (float)1.90);
            App.Database.SaveUselessThingAsync(DonaldTrump);

            UselessThing HotDog = AddUselessThing("Hot Dog", "Food", (float)0.043, (float)0.15);
            App.Database.SaveUselessThingAsync(HotDog);

            UselessThing Banana = AddUselessThing("Banana", "Food", (float)0.118, (float)0.1778);
            App.Database.SaveUselessThingAsync(Banana);

            UselessThing Pineapple = AddUselessThing("Pineapple", "Food", (float)0.907, (float)0.3);
            App.Database.SaveUselessThingAsync(Pineapple);

            UselessThing Panda = AddUselessThing("Panda", "Animal", (float)107, (float)1.55);
            App.Database.SaveUselessThingAsync(Panda);

            UselessThing HouseCat = AddUselessThing("House Cat", "Animal", (float)4.5, (float)0.76);
            App.Database.SaveUselessThingAsync(HouseCat);

            UselessThing GoldenRetriever = AddUselessThing("Golden Retriever", "Animal", (float)29, (float)1);
            App.Database.SaveUselessThingAsync(GoldenRetriever);

            UselessThing Titanic = AddUselessThing("Titanic", "Comically Large", (float)47454834, (float)269.1);
            App.Database.SaveUselessThingAsync(Titanic);

            UselessThing SpaceShuttleDiscovery = AddUselessThing("Space Shuttle Discovery", "Comically Large", (float)3600, (float)37.237);
            App.Database.SaveUselessThingAsync(SpaceShuttleDiscovery);

            UselessThing TheMoon = AddUselessThing("The Moon", "Comically Large", (float) BigInteger.Parse("73420000000000000000000"), (float)3474200);
            App.Database.SaveUselessThingAsync(TheMoon);
        }

        public Task<List<UselessThing>> GetUselessThingsAsync()
        {
            return DatabaseHelper.Table<UselessThing>().ToListAsync();
        }

        public Task<UselessThing> GetUselessThingAsync(int id)
        {
            return DatabaseHelper.Table<UselessThing>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<UselessThing> GetUselessThingByNameAsync(string name)
        {
            return DatabaseHelper.Table<UselessThing>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public Task<int> SaveUselessThingAsync(UselessThing item)
        {
            if (item.ID != 0)
            {
                return DatabaseHelper.UpdateAsync(item);
            }
            else
            {
                return DatabaseHelper.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(UselessThing item)
        {
            return DatabaseHelper.DeleteAsync(item);
        }
    }
}
