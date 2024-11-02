using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        string path = "/tmp/fnuméro.txt";

        FileStream fs = File.Create(path);

        fs.Close();

        string reponse = "oui";

        int nombre1 = 0, nombre2 = 0, nombre3 = 0, compteur2 = 0;

        String line1;

        String line, nom = "a", prenom = "b";

        char operation = 'z';

        string contenu50 = "";

        while (reponse.ToLower().Equals("oui"))
        {
            String n = "z";

            while ((!(n.Equals("1"))) && (!(n.Equals("2"))) && (!(n.Equals("3"))) && (!(n.Equals("4"))))
            {
                Console.Write("Bienvenue dans notre banque.\n Veuillez saisir votre nom : ");
                nom = Console.ReadLine();
    
                while (nom.Equals(""))
                {
                    Console.WriteLine("Aucune entrée saisie au clavier. Veuillez saisir votre nom : ");
                    nom = Console.ReadLine();
                }

                Console.Write("Veuillez saisir votre prénom : ");
                prenom = Console.ReadLine();

                while (prenom.Equals(""))
                {
                    Console.WriteLine("Aucune entrée saisie au clavier. Veuillez saisir votre prénom : ");
                    prenom = Console.ReadLine();
                }

                compteur2++;

                Console.WriteLine("Quel type d'opération voulez-vous effectuer ?");
                Console.WriteLine("1: Versement \n2: Retrait \n3: Informations\n4: Quitter");
                Console.WriteLine("Veuillez sélectionner un nombre (1, 2, 3 ou 4)");
                try
                {
                    // Tentative de conversion de la chaîne en entier
                    n = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erreur : La réponse n'est pas dans un format valide.");
                    break;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Erreur : La réponse représente un nombre trop grand ou trop petit pour un entier.");
                    break;
                }
                catch (Exception ex)
                {
                    // Pour capturer d'autres exceptions potentielles
                    Console.WriteLine($"Une erreur inattendue est survenue : {ex.Message}");
                    break;
                }
            }
            
            int compteur = 0;

            StreamReader sr1 = new StreamReader("/tmp/fnuméro.txt");

            line1 = sr1.ReadToEnd();
            sr1.Close();

            if (compteur2 > 1)
            {

                StreamReader sr50 = new StreamReader(path);
                contenu50 = sr50.ReadToEnd();
                sr50.Close();

            }
            
            if (n.Equals("1")) 
            {
                operation = 'V'; 
                Console.WriteLine ("Versement\n");
                nombre1++;

                StreamWriter swNew = new StreamWriter(path);

                if (compteur2 > 1)
                {

                    swNew.WriteLine(contenu50);
                }

                swNew.Write ("Nom : " + nom + " - Prenom : " + prenom);

                swNew.Write(" V - " + nombre1);
                swNew.WriteLine();
                swNew.Close();
            }
            else if (n.Equals("2"))
            {
                operation = 'R';
                Console.WriteLine ("Retrait\n");
                nombre2++;

                StreamWriter swNew = new StreamWriter(path);

                if (compteur2 > 1)
                {

                    swNew.WriteLine(contenu50);
                }
  
                swNew.Write ("Nom : " + nom + " - Prenom : " + prenom);

                swNew.Write(" R - " + nombre1);
                swNew.WriteLine();
                swNew.Close();
            }
            else if (n.Equals("3"))
            {
                operation = 'I';
                Console.WriteLine ("Informations\n");
                nombre3++;

                StreamWriter swNew = new StreamWriter(path);

                if (compteur2 > 1)
                {

                    swNew.WriteLine(contenu50);
                }

                swNew.Write ("Nom : " + nom + " - Prenom : " + prenom);

                swNew.Write(" I - " + nombre1);
                swNew.WriteLine();
                swNew.Close();
            }
            else if (n.Equals("4"))
            {
                Console.WriteLine("Au revoir et a bientôt !!!");
                break;
            }

            StreamReader sr = new StreamReader("/tmp/fnuméro.txt");
            
            line = sr.ReadToEnd();

               foreach (char c in line)
               {
                 if (c == operation)
                    compteur++;
               }

                sr.Close();

                string message = "Votre numéro est " + compteur + " et il y'a " + --compteur + " personnes qui attendent avant vous";
        
                Console.WriteLine(message);

                Console.WriteLine("Souhaitez-vous prendre un autre numéro ? (Saisir oui ou non)");

                reponse = Console.ReadLine();

                while (!(reponse.ToLower().Equals("oui")) && (!(reponse.ToLower().Equals("non"))))
                {
                    Console.WriteLine("Réponse incorrecte");
                    Console.WriteLine("Veuillez saisir oui ou non si vous souhaiter prendre un autre numéro ? (Saisir oui ou non)");
                    reponse = Console.ReadLine();
                }
            }
        

        StreamReader sr100 = new StreamReader(path);
        string contenu = sr100.ReadToEnd();
        sr100.Close();

        if (!contenu.Equals(""))
        {
            Console.WriteLine("-----------Historique des clients et de leurs tickets-----------");
            Console.WriteLine(contenu);
        }

        File.Delete(path);
    }

}
