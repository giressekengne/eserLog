using System;
using System.Linq;
using System.Text;

namespace eserLog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var log = Log.Instance();
            Person pers = new Person("Giresse", "Kengne", "24");
            log.WriteLog<Person>(pers);
        }
    }

    public class Person
    {
        private string nome;
        private string cognome;
        private string matricola;

        public Person (string nome, string cognome, string matricola)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.matricola = matricola;
        }

        public string getNome()
        {
            return nome;
        }

        public void setNome(string nome)
        {
            this.nome=nome;
        }

        public string getCognome()
        {
            return cognome;
        }

        public void setCogome(string cognome)
        {
            this.cognome = cognome;
        }

        public string getMatricola()
        {
            return matricola;
        }

        public void setMatricola(string matricola)
        {
            this.matricola = matricola;
        }
    }

    public class Log
    {
        private static string _Path;
        private static Log _instance; private Log()
        {
            _Path = @"C:\LOG\class.csv";
        }
        public static Log Instance()
        {
            if (_instance == null)
            {
                _instance = new Log();
            }
            return _instance;
        }
        public void WriteLog<T>(T message) where T : class
        {
            StringBuilder prov = new StringBuilder();
            var prova = message.GetType().GetProperties().ToList();

            prov.AppendLine($"Tipo classe: {message.GetType().Name}");
            prov.AppendLine();
            prov.AppendLine($"Proprietà: ");
            foreach (var item in prova)
            {
                prov.AppendLine($"{item.Name}, {item.GetValue(message)}");
            }

            File.AppendAllText(_Path, prov.ToString());
        }


    }
}
