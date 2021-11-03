using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Modul3Oblig1
{
    public class FamilyApp
    {
        private List<Person> Familylist;


        public FamilyApp(Person sverreMagnus, Person ingridAlexandra, Person haakon)
        {
            Familylist = new List<Person>();
            Familylist.Add(sverreMagnus);
            Familylist.Add(ingridAlexandra);
            Familylist.Add(haakon);

        }

        public FamilyApp(Person sverreMagnus, Person ingridAlexandra, Person haakon, Person metteMarit, Person marius,
            Person harald, Person sonja, Person olav)
        {
            Familylist = new List<Person>();
            Familylist.Add(sverreMagnus);
            Familylist.Add(ingridAlexandra);
            Familylist.Add(haakon);
            Familylist.Add(metteMarit);
            Familylist.Add(marius);
            Familylist.Add(harald);
            Familylist.Add(sonja);
            Familylist.Add(olav);

        }

        public string WelcomeMessage { get; set; } = "Velkommen til kongehuset";
        public string CommandPrompt { get; set; } = "Vis ID ";

        public string HandleCommand(string command)
        {
            // Dersom command innholder "vis" blir IsShowCommand true. Vis Command = vis 3
            bool IsShowCommand = command.Contains("vis");

            // command.Contains("vis");
            if (IsShowCommand)
            {
                // spliter komandordet til et string array. command array [0] = vis. command array [1] = 3
                var CommandArray = command.Split(" ");
                //
                var GetId = CommandArray[1];
                
                var PersonToShow = Familylist.Where(x => x.Id.ToString() == GetId).FirstOrDefault().GetDescription(out int id);
                var Childeren = "\n  Barn:";

                bool hasChilderen = false;


                foreach (var person in Familylist)
                {
                    int fatherId = person.Father?.Id ?? -1;
                    int motherId = person.Mother != null ? person.Mother.Id : -1; 

                    if (fatherId == id || motherId == id)
                    {
                        Childeren += "\n" + person.GetChilderen();
                        hasChilderen = true;
                    }
                }
                Childeren += "\n";
                if (hasChilderen) PersonToShow += Childeren;
               
                return PersonToShow;
            }

            return null;
        }
    }
}
