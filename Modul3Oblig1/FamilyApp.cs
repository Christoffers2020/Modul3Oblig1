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
        private static List<Person> _people;
        public static string ShowMenu()
        {
            string MenuTxt = "\r\nhjelp => viser en hjelpetekst som forklarer alle kommandoene \r\n"  +
                             "liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert.\r\n" +
                             "vis <id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem\r\n";
            
            return MenuTxt;
        }

        public static string ShowPeople()
        {
            string PeopleDescription = " ";

            foreach (var Person in _people)
            {
               
                PeopleDescription +=  Person.GetDescription();
            }

            return PeopleDescription;
        }

        


        public FamilyApp(params Person[] people)
        {
            _people = new List<Person>(people);
            CommandPrompt = ShowMenu();
        }

        public string WelcomeMessage { get; set; } = "Velkommen til kongehuset";
        public string CommandPrompt { get; set; } 
        public string HandleCommand(string command)
        {
            // Dersom command innholder "vis" blir IsShowCommand true. Vis Command = vis 3
            bool IsShowCommand = command.Contains("vis");
            bool IsHelpCommand = command.Contains("hjelp");
            bool IsListCommand = command.Contains("liste");

            // command.Contains("vis");
            if (IsShowCommand)
            {
                return ShowPerson(command);
            }

            if (IsHelpCommand)
            {
                return ShowMenu();
            }

            if (IsListCommand)
            {
                return ShowPeople();
            }
            return null;
        }

        public string ShowPerson(string command)
        {

            // spliter komandordet til et string array. command array [0] = vis. command array [1] = 3
            var CommandArray = command.Split(" ");
            //
            var GetId = CommandArray[1];

            var PersonToShow = _people.Where(x => x.Id.ToString() == GetId).FirstOrDefault().GetDescription();
            var Childeren = "\n  Barn:";

            bool hasChilderen = false;


            foreach (var person in _people)
            {
                // for å vise barn som ikke har far eller mor.
                int fatherId = person.Father?.Id ?? -1;
                int motherId = person.Mother != null ? person.Mother.Id : -1;

                if (fatherId == person.Id || motherId == person.Id)
                {
                    Childeren += "\n" + person.GetChilderen();
                    hasChilderen = true;
                }
            }
            Childeren += "\n";
            if (hasChilderen) PersonToShow += Childeren;

            return PersonToShow;
        }
    }
}
