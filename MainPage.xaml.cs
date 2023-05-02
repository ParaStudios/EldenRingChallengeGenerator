
namespace Elden_Ring_Challenge_Generator;

public partial class MainPage : ContentPage
{
    int iZahl;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnChallengeStartClicked(object sender, EventArgs e)
    {
        if (CheckConsumablesOnly())
        {
            DisplayAlert("Deine Challenge Vorgaben:",
                $"Ausnahmefall CONSUMABLES ONLY RUN!!!!!!{Environment.NewLine}" +
                $"Startklasse: {GetStarterklasse()} {Environment.NewLine}" +
                $"Startwaffe: keine. Muss nach dem ersten Mini-Boss sofort entsorgt werden (wo man sterben darf der Anfangsboss). {Environment.NewLine}" +
                $"Startandenken: {GetStarterAndenken()} {Environment.NewLine}" +
                $"Ausrüstungsgewicht: {GetGewicht()} {Environment.NewLine}" +
                $"Ausrüstungsslots: {GetRüstungsslots()} {Environment.NewLine}" +
                $"Permanent Consumables: aufgrund Consumables only-run sind alle erlaubt!  {Environment.NewLine}" +
                $"Maximallevel: {GetLevelCap()}  {Environment.NewLine}",
                "Consumables-Only lets go! :)");
        }
        else
        {
            //3 Starterkarten
            for (int i = 1; i <= 3; i++)
            {
                DisplayAlert($"Option {i}", $"Nachfolgend wird dir deine {i}. Option von 3 angezeigt.", $"Zeige mir diese {i}. Option");

                //erlaubte Waffen bestimmen
                string erlaubteWaffen = "";
                for (int j = 0; j < GetWaffenAnzahl(); j++)
                {
                    erlaubteWaffen += $"{GetWaffe()}, ";
                }
                erlaubteWaffen = erlaubteWaffen.Remove(erlaubteWaffen.Length - 2, 2);

                DisplayAlert("Deine Challenge Vorgaben:",
                $"Startklasse: {GetStarterklasse()} {Environment.NewLine}" +
                $"Startwaffe: {GetStartwaffeBehalten()} {Environment.NewLine}" +
                $"Startandenken: {GetStarterAndenken()} {Environment.NewLine}" +
                $"Ausrüstungsgewicht: {GetGewicht()} {Environment.NewLine}" +
                $"Ausrüstungsslots: {GetRüstungsslots()} {Environment.NewLine}" +
                $"Erlaubte Waffe(n): {erlaubteWaffen} {Environment.NewLine}" +
                $"Waffenduplikate: {GetDuplikateErlaubt()} {Environment.NewLine}" +
                $"Consumables: {GetConsumablesErlaubt()}  {Environment.NewLine}" +
                $"Permanent Consumables: {GetPermanentConsumablesErlaubt()}  {Environment.NewLine}" +
                $"Maximallevel: {GetLevelCap()}  {Environment.NewLine}",
                "Crazy shit! :)");
                       
                
            }
        }

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private static string GetWaffe()
    {
        List<string> Waffenliste = new()
        {
            "Dolch",
            "Parierdolch",
            "Misericordia",
            "Großes Messer",
            "Blutbefleckter Dolch",
            "Erdenstahldolch",
            "Wakizashi",
            "Zelebrantensichel",
            "Elfenbeinsichel",
            "Kristallmesser",
            "Skorpionstachel",
            "Cinqueda",
            "Schimmersteinkris",
            "Reduvia",
            "Klinge des Rufs",
            "Schwarzes Messer",
            "Kurzschwert",
            "Langschwert",
            "Breitschwert",
            "Altes Schwert",
            "Schwert der Getreuen",
            "Feines Adligenschwert",
            "Stockschwert",
            "Kriegsfalkenkralle",
            "Lazuli-Schimmersteinschwert",
            "Carianisches Ritterschwert",
            "Kristallschwert",
            "Fäulniskristallschwert",
            "Miquella-Ritterschwert",
            "Ornamentales Schwert",
            "Goldenes Epitaphium",
            "Schwert von St Trina",
            "Eochaids Zierde",
            "Schwert der geheimen Worte",
            "Schwert der Nacht und der Flamme",
            "Bastardschwert",
            "Claymore",
            "Eisengroßschwert",
            "Großschwert der Getreuen",
            "Rittergroßschwert",
            "Großschwert der Exilritter",
            "Gegabeltes Großschwert",
            "Flamberge",
            "Gargoyle-Großschwert",
            "Gargoyle-Schwarzschwert",
            "Unzertrennliches Schwert",
            "Milos-Schwert",
            "Henkerschwert der Marais",
            "Ordovis Großschwert",
            "Alabasterfürstenschwert",
            "Schüreisen des Todes",
            "Helphens Spitzturm",
            "Blasphemische Klinge",
            "Großschwert der Goldenen Ordnung",
            "Dunkelmondgroßschwert",
            "Heiliges Reliktschwert",
            "Großschwerter der Sternengeißel",
            "Zweihänder",
            "Großschwert",
            "Großschwert des Bewachers",
            "Goldenes Trollschwert",
            "Trollritterschwert",
            "Königliches Großschwert",
            "Großschwert der Verpflanzung",
            "Trümmergroßschwert",
            "Großschwert der Gottestöterin",
            "Malikeths schwarze Klinge",
            "Rapier",
            "Panzerbrecher",
            "Adeligenpanzerbrecher",
            "Schwert des Reinfäule-Ritters",
            "Rogiers Rapier",
            "Ameisenstachel-Rapier",
            "Eisnadel",
            "Großer Degen",
            "Götterskalpnadel",
            "Blutige Helix",
            "Felsklinge des Drachenkönigs",
            "Krummsäbel",
            "Falchion",
            "Shamshir",
            "Großmesser",
            "Banditenkrummschwert",
            "Shotel",
            "Plündererkrummschwert",
            "Mantisklinge",
            "Bestienkrummschwert",
            "Fließendes Krummschwert",
            "Schlangengottkrummschwert",
            "Magmaklinge",
            "Fließendes Noxschwert",
            "Schwinge von Astel",
            "Shotel der Eklipse",
            "Reitergeißel",
            "Malbeil",
            "Mönchsflammenschwert",
            "Beil des Bestienmenschen",
            "Bluthundreißzahn",
            "Onyxfürstengroßschwert",
            "Zamorkrummschwert",
            "Magmalindwurm-Schuppenschwert",
            "Morgotts verfluchtes Schwert",
            "Uchigatana",
            "Nagakiba",
            "Schlangenknochenklinge",
            "Meteorklinge",
            "Mondschleier",
            "Blutige Ströme",
            "Drachenschuppenklinge",
            "Malenias Hand",
            "Doppelklinge",
            "Ritter-Zwillingsschwerter",
            "Götterskalphäuter",
            "Gargoyle-Doppelklinge",
            "Gargoyle-Doppelschwarzklinge",
            "Eleonoras Stangenwaffe",
            "Handaxt",
            "Gespaltene Sichel",
            "Streitaxt",
            "Verformte Axt",
            "Kieferknochen-Axt",
            "Eisenbeil",
            "Hochlandaxt",
            "Zelebrantenbeil",
            "Opferpriesteraxt",
            "Eisiges Beil",
            "Wellenklinge",
            "Sturmfalkenaxt",
            "Rosus Axt",
            "Godricks Axt",
            "Großaxt",
            "Halbmondaxt",
            "Langstielbeil",
            "Henkergroßaxt",
            "Maltöter-Großbeil",
            "Rostiger Anker",
            "Fleischermesser",
            "Gargoyle-Großaxt",
            "Gargoyle-Schwarzaxt",
            "Schwingengroßhorn",
            "Keule",
            "Geschwungene Keule",
            "Stachelkeule",
            "Steinkeule",
            "Streitkolben",
            "Morgenstern",
            "Spaltaxt",
            "Hammer",
            "Mönchsflammenstreitkolben",
            "Varrés Blumenstrauß",
            "Horn des Gesandten",
            "Fließender Noxhammer",
            "Beringter Finger",
            "Zepter des Allwissenden",
            "Marikas Hammer",
            "Bastardsterne",
            "Flegel",
            "Flegel der Dunkelkavallerie",
            "Kettenflegel",
            "Köpfe der Familie",
            "Große Keule",
            "Geschwungene Großkeule",
            "Großstreitkolben",
            "Spitzhacke",
            "Ziegelhammer",
            "Streithammer",
            "Fäulnisstreithammer",
            "Zelebrantenschädel",
            "Großsterne",
            "Großhornhammer",
            "Langhorn des Gesandten",
            "Schädelkerzenständer",
            "Bestienklauengroßhammer",
            "Verschlingerzepter",
            "Duellantengroßaxt",
            "Fäulnisgroßaxt",
            "Golemhellebarde",
            "Riesenbrecher",
            "Infernalischer Prälatenstab",
            "Großkeule",
            "Trollhammer",
            "Große Drachenkralle",
            "Stab des Bewachers",
            "Stab des Avatars",
            "Fäulnisstab",
            "Großhorn des Gesandten",
            "Ghizas Rad",
            "Sternenfallbestienkiefer",
            "Godfreys Axt",
            "Kurzspeer",
            "Eisenspeer",
            "Speer",
            "Partisane",
            "Pike",
            "Stachelspeer",
            "Kreuz-Naginata",
            "Tonmenschenharpune",
            "Zelebrantenrippenharke",
            "Stabfackel",
            "Girandole des Inquisitors",
            "Kristallspeer",
            "Fäulniskristallspeer",
            "Reinfäule-Speer",
            "Todesritualspeer",
            "Blitz von Gransax",
            "Lanze",
            "Baumspeer",
            "Schlangenjäger",
            "Silurias Baum",
            "Vykes Kriegsspeer",
            "Mohgwyns heiliger Speer",
            "Hellebarde",
            "Hellebarde der Exilritter",
            "Falkenschnabel",
            "Gleve",
            "Shotel der Niederen Soldaten",
            "Säge der Niederen Soldaten",
            "Wächter-Schwertspeer",
            "Gargoyle-Hellebarde",
            "Gargoyle-Schwarzhellebarde",
            "Gleve der Dunkelkavallerie",
            "Seuchengleve",
            "Wellenhellebarde",
            "Goldene Hellebarde",
            "Drachenhellebarde",
            "Lorettas Kriegssichel",
            "Kommandantenstandarte",
            "Sense",
            "Grabsense",
            "Aureolensense",
            "Schwingensense",
            "Peitsche",
            "Dornenpeitsche",
            "Urumi",
            "Hoslows Blütenpeitsche",
            "Magmapeitschenleuchter",
            "Roter Riesenhaarzopf",
            "Verpflanzter Drache",
            "Caestus",
            "Stachelcaestus",
            "Katar",
            "Eisenkugel",
            "Sternfaust",
            "Greifende Knochenhand",
            "Veteranenprothese",
            "Verschlüsseltes Pata",
            "Hakenkrallen",
            "Bluthundkrallen",
            "Schlangenzahn",
            "Raptorkrallen",
            "Kurzbogen",
            "Kompositbogen",
            "Rotholzkurzbogen",
            "Scheusalkurzbogen",
            "Harfenbogen",
            "Langbogen",
            "Bogen der Albinaurics",
            "Schwarzer Bogen",
            "Flaschenzugbogen",
            "Hornbogen",
            "Schlangenbogen",
            "Erdenbaum-Bogen",
            "Löwengroßbogen",
            "Großbogen",
            "Golemgroßbogen",
            "Erdenbaum-Großbogen",
            "Soldatenarmbrust",
            "Leichte Armbrust",
            "Schwere Armbrust",
            "Arbalest",
            "Crepus Schwarzschlüsselarmbrust",
            "Flaschenzugarmbrust",
            "Vollmondarmbrust",
            "Handballiste",
            "Gefäßkanone",
            "Carianisches königliches Zepter",
            "Astrologenstab",
            "Schimmersteinstab",
            "Akademie-Schimmersteinstab",
            "Gräberstab.png	Gräberstab",
            "Stab der Halbmenschenkönigin",
            "Azurner Schimmersteinstab",
            "Lusats Schimmersteinstab",
            "Carianischer Schimmersteinstab",
            "Carianischer Schimmerklingenstab",
            "Albinauric-Stab",
            "Stab des Verlusts",
            "Schimmersteinstab vom Gelmir",
            "Kristallstab",
            "Fäulniskristallstab",
            "Meteoritenstab",
            "Stab der Schuldigen",
            "Stab des Todesprinzen",
            "Finger-Siegel",
            "Siegel des Erdenbaums",
            "Siegel der Goldenen Ordnung",
            "Schottersteinsiegel",
            "Siegel des Riesen",
            "Siegel des Gottestöters",
            "Klauenzeichen-Siegel",
            "Siegel der Rasenden Flamme",
            "Siegel der Drachenkommunion",
            "Schrottschild (Rickety Shield)",
            "Vernieteter Rundschild (Riveted Wooden Shield)",
            "Blau-weißer Holzschild (Blue-White Wooden Shield)",
            "Runenverzierter Rundschild (Scripture Wooden Shield)",
            "Rotdornrundschild (Red Thorn Roundshield)",
            "Prangerschild (Pillory Shield)",
            "Faustschild (Buckler)",
            "Eisenrundschild (Iron Roundshield)",
            "Vergoldeter Eisenschild (Gilded Iron Shield)",
            "Schlangenmenschenschild (Man-Serpent's Shield)",
            "Eiswappenschild (Ice Crest Shield)",
            "Rissschild (Rift Shield)",
            "Parfümeurschild (Perfumer's Shield)",
            "Schild der Schuldigen (Shield of the Guilty)",
            "Hornbewehrter Schild (Spiralhorn Shield)",
            "Schwelender Schild (Smoldering Shield)",
            "Spiralschild (Coil Shield)",
            "Holzschild mit Falkenwappen (Hawk Crest Wooden Shield)",
            "Holzschild mit Pferdewappen (Horse Crest Wooden Shield)",
            "Kerzenbaum-Holzschild (Candletree Wooden Shield)",
            "Holzschild mit Flammenwappen (Flame Crest Wooden Shield)",
            "Ramponierter Holzschild (Marred Wooden Shield)",
            "Schild des Sonnenreichs (Sun Realm Shield)",
            "Rundschild (Round Shield)",
            "Großer Lederschild (Large Leather Shield)",
            "Schwarzer Lederschild (Black Leather Shield)",
            "Ramponierter Lederschild (Marred Leather Shield)",
            "Dreieckschild (Heater Shield)",
            "Schwarzwappen-Dreieckschild (Blue Crest Heater Shield)",
            "Rotwappen-Dreieckschild (Red Crest Heater Shield)",
            "Bestien-Dreieckschild (Beast Crest Heater Shield)",
            "Falkensturz-Dreieckschild (Inverted Hawk Heater Shield)",
            "Eklipse-Dreieckschild (Eclipse Crest Heater Shield)",
            "Drachenschild (Kite Shield)",
            "Blau-goldener Drachenschild (Blue-Gold Kite Shield)",
            "Skorpionsdrachenschild (Scorpion Kite Shield)",
            "Zwillingsvogel-Drachenschild (Twinbird Kite Shield)",
            "Messingschild (Brass Shield)",
            "Schild der Exilritter (Banished Knight's Shield)",
            "Schild der Albinaurics (Albinauric Shield)",
            "Bestiengefäßschild (Beastman's Jar-Shield)",
            "Carianischer Ritterschild (Carian Knight's Shield)",
            "Silberner Spiegelschirm (Silver Mirrorshield)",
            "Riesenschildkrötenpanzer (Great Turtle Shell)",
            "Holzgroßschild (Wooden Greatshield)",
            "Schild der Getreuen (Lordsworn's Shield)",
            "Dornengroßschild (Briar Greatshield)",
            "Stachelpalisadenschild (Spiked Palisade Shield)",
            "Ikonenschild (Icon Shield)",
            "Goldener Bestienschild (Golden Beast Crest Shield)",
            "Bollwerksturmschild (Manor Towershield)",
            "Turmschild der Verflechtung (Crossed-Tree Towershield)",
            "Falkensturz-Turmschild (Inverted Hawk Towershield)",
            "Drachenturmschild (Dragon Towershield)",
            "Edler Großschild (Distinguished Greatshield)",
            "Vergoldeter Großschild (Gilded Greatshield)",
            "Kuckucksgroßschild (Cuckoo Greatshield)",
            "Rotmähnen-Großschild (Redmane Greatshield)",
            "Goldener Großschild (Golden Greatshield)",
            "Haligbaumwappen-Großschild (Haligtree Crest Greatshield)",
            "Hornschild des Schmelztiegels (Crucible Hornshield)",
            "Drachenklauenschild (Dragonclaw Shield)",
            "Fingerabdruck-Steinschild (Fingerprint Stone Shield)",
            "Eklipse-Großschild (Eclipse Crest Greatshield)",
            "Ameisenschädelplatte (Ant's Skull Plate)",
            "Erdenbaum-Großschild (Erdtree Greatshield)",
            "Quallenschild (Jellyfish Shield)",
            "Feuerspuckerschild (Visage Shield)",
            "Einäugiger Schild (One-Eyed Shield)"
        };

        Random rnd = new();
        return Waffenliste[rnd.Next(371)];
    }
    private string GetGewicht()
    {
        Random rnd = new();
        iZahl = rnd.Next(99);
        return iZahl switch
        {
            //30%
            int n when (n >= 0 && n <= 29) => "Leichte Rolle",
            //30%
            int n when (n >= 30 && n <= 59) => "Mittlere Rolle",
            //30%
            int n when (n >= 60 && n <= 89) => "Schwere Rolle",
            //9%
            int n when (n >= 90 && n <= 98) => "Freie Wahl",
            _ => "Überladen!",//1%
        };
    }
    private string GetDuplikateErlaubt()
    {
        Random rnd = new();
        iZahl = rnd.Next(2);
        return iZahl switch
        {
            //50%
            1 => "erlaubt!",
            //50%
            _ => "nicht erlaubt!",
        };
    }
    private string GetConsumablesErlaubt()
    {
        Random rnd = new();
        iZahl = rnd.Next(99);
        return iZahl switch
        {
            int n when (n >= 0 && n <= 79) => "erlaubt!", //80%
            _ => "nicht erlaubt!", //20%
        };
    }
    private string GetPermanentConsumablesErlaubt()
    {
        Random rnd = new();
        iZahl = rnd.Next(99);
        return iZahl switch
        {
            int n when (n >= 0 && n <= 79) => "nicht erlaubt!", //80%
            _ => "erlaubt!",//20%
        };
    }
    private string GetLevelCap()
    {
        Random rnd = new();
        iZahl = rnd.Next(100, 152);
        if (iZahl == 151)
        {
            return "unlimitiert!";
        }
        else
        {
            return iZahl.ToString();
        }

    }
    private string GetStarterklasse()
    {
        Random rnd = new();
        iZahl = rnd.Next(18);
        return iZahl switch
        {
            int n when (n == 9) => "Vagabund",
            int n when (n == 10) => "Krieger",
            int n when (n == 11) => "Held",
            int n when (n == 12) => "Bandit",
            int n when (n == 13) => "Astrologe",
            int n when (n == 14) => "Prophet",
            int n when (n == 15) => "Samurai",
            int n when (n == 16) => "Gefangener",
            int n when (n == 17) => "Bekenner",
            _ => "Bettler",
        };
    }
    private string GetStartwaffeBehalten()
    {
        Random rnd = new();
        iZahl = rnd.Next(99);
        return iZahl switch
        {
            int n when (n >= 0 && n <= 94) => "nach Waffenfund wegwerfen!", //95%
            _ => "darf permanent behalten werden!", //5%
        };
    }
    private string GetStarterAndenken()
    {
        Random rnd = new();
        iZahl = rnd.Next(10);
        return iZahl switch
        {
            0 => "Rotes Bernsteinmedaillon",
            1 => "Zwischenlandrune",
            2 => "Goldene Saat",
            3 => "Asche der Vampirwichte",
            4 => "Gesprungene Töpfe",
            5 => "Steinschwertschlüssel",
            6 => "Betörende Äste",
            7 => "Gekochte Garnelen",
            8 => "Shabriris Kummer",
            _ => "Kein Andenken!",
        };
    }
    private string GetRüstungsslots()
    {
        Random rnd = new();
        iZahl = rnd.Next(99);
        return iZahl switch
        {
            int n when (n == 0) => "Keine Schuhe!",
            int n when (n == 1) => "Keine Hose!",
            int n when (n == 2) => "Keine Schuhe und keine Hose!",
            int n when (n == 3) => "Keine Schuhe!",
            int n when (n == 4) => "Kein Brustpanzer!",
            int n when (n == 5) => "Kein Brustpanzer und keine Schuhe!",
            int n when (n == 6) => "Kein Brustpanzer und keine Hose!",
            int n when (n == 7) => "Kein Brustpanzer, keine Hose und keine Schuhe!",
            int n when (n == 8) => "Kein Helm!",
            int n when (n == 9) => "Kein Helm und keine Schuhe!",
            int n when (n == 10) => "Kein Helm und keine Hose!",
            int n when (n == 11) => "Kein Helm, keine Hose und keine Schuhe!",
            int n when (n == 12) => "Kein Helm und kein Brustpanzer!",
            int n when (n == 13) => "Kein Helm, kein Brustpanzer und keine Schuhe!",
            int n when (n == 14) => "Kein Helm, kein Brustpanzer und keine Hose!",
            int n when (n == 15) => "Kein Helm, kein Brustpanzer, keine Hose und keine Schuhe!",
            _ => "Kein Handicap!",//84%
        };
    }
    private bool CheckConsumablesOnly()
    {
        Random rnd = new();
        iZahl = rnd.Next(99);
        return iZahl switch
        {
            int n when (n == 0) => true, //1%
            _ => false, //99%
        };
    }
    private int GetWaffenAnzahl()
    {
        //Waffenanzahl 1 - 6 Stück: 50 % 30 % 14 % 3 % 2 % 1 %
        Random rnd = new();
        iZahl = rnd.Next(99);
        return iZahl switch
        {
            int n when (n >= 0 && n <= 49) => 1,
            int n when (n >= 50 && n <= 79) => 2,
            int n when (n >= 80 && n <= 93) => 3,
            int n when (n >= 94 && n <= 96) => 4,
            int n when (n >= 97 && n <= 98) => 5,
            _ => 6,
        };
    }
}






/*
<Ausrüstungsgewicht -> 33% Leichte  33% Mittlere     33% Schwere      1% überlastet
<Waffe alle zufällig auch gleiche möglich für Duplikat
Waffenanzahl 1-6 Stück: 50% 30% 14% 3% 2% 1%
<Duplikate explizit trotzdem ermöglichen: 50% 50%
<Consumables 80% yes 20% no
<AllowPermanentItems 20% yes 80%no
<Level 100-150
<Kein Levellimit 2%free 98%
<Consumables Only Run 1%ja 99%nein
<Klassenwahl: 50% Bettler Rest aufteilen fair
<Starterwaffe verwenden bis eine erste Waffe gefunden wird: 95%ja 5%nein
<Startgegenstand (Andenken): 10% für jeden (10 Stück)

Elden Ring ist durch wenn man alle 15 Echos gefickt hat
(Siegel bzw. bestimmte Zauberstäbe nur benutzen was dazu passt. Waffen welche automatisch mit 1 Item zum Zweihänder sich duplizieren sind von allem ausgenommen und dürfen benutzt werden)
Keine Schuhe/Hose/Body/Helm jeweils immer 2%

*/

