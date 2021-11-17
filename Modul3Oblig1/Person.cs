using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3Oblig1
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public int Id { get; set; }

        public Person Father { get; set; } 
        public Person Mother { get; set; }


        public string GetDescription()
        {
           // id = Id;
            string Description = "";

            Description += addField(FirstName, "", " ");
            Description += addField(LastName, "", " ");
            Description += addField(Id, "(Id=", ") ");
            Description += addField(BirthYear,"Født: ", " ");
            Description += addField(DeathYear, "Død: ", " ");
            if (Father != null)
            {
                Description += addField(Father.FirstName, "Far: ", " ");

                Description += addField(Father.Id, "(Id=", ")");
            }

          if (Mother != null)
          {
              Description += addField(Mother.FirstName, "Mor: ", " ");

              Description += addField(Mother.Id, "(Id=", ")");

            }
          
            return Description;
        }

        public string addField(object Value, string PreFix, string PostFix)
        {
            string fieldDescription = "";

            if (Value != null )
            {
                fieldDescription += PreFix;
                fieldDescription += Value;
                fieldDescription += PostFix;
            }

            return fieldDescription;

        }

        public string GetChilderen()
        {
            return $"    {FirstName} (Id={Id}) Født: {BirthYear}";
        }
    }
}

