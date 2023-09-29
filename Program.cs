using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAppRose
{
    internal class Program
    {

        struct Cours
        {
            private int id_cours;
            private string nom_cours;
            private int nbre_heures;
            private double note_etudiant;

            public int Id_cours { get => id_cours; set => id_cours = value; }
            public string Nom_cours { get => nom_cours; set => nom_cours = value; }
            public int Nbre_heures { get => nbre_heures; set => nbre_heures = value; }
            public double Note_etudiant { get => note_etudiant; set => note_etudiant = value; }

            public Cours(int id_cours, string nom_cours, int nbre_heures, double note_etudiant)
            {
                this.id_cours = id_cours;
                this.nom_cours = nom_cours;
                this.nbre_heures = nbre_heures;
                this.note_etudiant = note_etudiant;
            }
        }//cours
        struct Etudiant
        {
            private int id_etudiant;
            private string nom_etudiant;
            private string prenom_etudiant;
            private Cours[] cours_etudiants;

            public Etudiant(int id_etudiant, string nom_etudiant, string prenom_etudiant, Cours[] cours_etudiants)
            {
                this.id_etudiant = id_etudiant;
                this.nom_etudiant = nom_etudiant;
                this.prenom_etudiant = prenom_etudiant;
                this.cours_etudiants = cours_etudiants;
            }

            public int Id_etudiant { get => id_etudiant; set => id_etudiant = value; }
            public string Nom_etudiant { get => nom_etudiant; set => nom_etudiant = value; }
            public string Prenom_etudiant { get => prenom_etudiant; set => prenom_etudiant = value; }
            public Cours[] Cours_etudiants { get => cours_etudiants; set => cours_etudiants = value; }



        }//etudiant

        //donnees globales
        static Etudiant[] etudiants = new Etudiant[10];
        static int nbrEtudiants = 0;
        //string[,] tab = new string[10, 4];


        static void Main(string[] args)
        {

            int essaisRestants = 3;
            string nomUtilisateur = "examen";
            string motDePasse = "1234";

            while (essaisRestants > 0)
            {
                Console.Write("Entrez votre nom d'utilisateur : ");
                nomUtilisateur = Console.ReadLine();

                Console.Write("Entrez votre mot de passe : ");
                motDePasse = Console.ReadLine();

                if (nomUtilisateur == "examen" && motDePasse == "1234")
                {
                    Console.WriteLine("Authentification réussie.");
                    String rep;
                    String choix;

                    do
                    {
                        Console.Write(" ===================================================\n"
                                    + " ********** GESTION DU COLLEGE DE ROSE ************ \n"
                                    + "====================================================\n"
                                    + "1. Ajouter un nouvel etudiant\n"
                                    + "2. Lister les etudiants format abrege\n"
                                    + "3. Lister les etudiants format detaille\n"
                                    + "4. Lister les etudiants avec leurs moyennes\n"
                                    + "5. Supprimer un etudiant\n"
                                    + "6. Quitter l'application\n");
                        do
                        {
                            Console.Write("Entrer votre choix: ");
                            choix = Console.ReadLine();
                        } while (choix != "1" && choix != "2" && choix != "3" && choix != "4" && choix != "5" && choix != "6");

                        switch (choix)
                        {
                            case "1":
                                ajoutEtudiant();
                            
                                break;
                            case "2":
                                afficherEtudiantFormatabrege();
                                break;
                            case "3":
                                afficherEtudiantFormatDetaille();
                                break;
                            case "4":
                                calculerMoyenne();
                                afficherCoursParEtudiant(etudiants);
                                break;
                            case "5":
                                supprimerEtudiant(etudiants);
                                break;
                            case "6":
                                Console.WriteLine("Au revoir");
                                break;

                            default:
                                Console.WriteLine("Choix invalide");
                                break;
                        }

                        do
                        {
                            Console.WriteLine("Voulez vous continuer?: ");
                            rep = Console.ReadLine();
                        } while (rep != "non" && rep != "oui");
                    } while (rep == "oui");

                    break;
                }
                else
                {
                    essaisRestants--;
                    Console.WriteLine("Nom d'utilisateur ou mot de passe incorrect. Il vous reste {0} essai(s).", essaisRestants);
                }
            }

            if (essaisRestants == 0)
            {
                Console.WriteLine("Nombre maximum d'essais atteint. Programme terminé,contacter la direction");
            }
        

            


            Console.ReadKey();
        }//main

        public static bool checkIdEtudiant(string[,] tab, int id)
        {
            bool check = true;
            string idstr = id.ToString();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (idstr.Equals(tab[i, j]))
                    {

                        check = false; break;
                    }

                }

            }
            return check;
        }

        public static void ajoutEtudiant()
        {
            Console.WriteLine();
            Console.WriteLine("*********** Ajout d`etudiant *************");
            string nom="", prenom="";
            int id_etud =0,id_cou;
            string[,] tab = new string[10, 4];

            //do
            //{
            //    Console.WriteLine("Entrer l'id de l'étudiant: ");
            //    id_etud = int.Parse(Console.ReadLine());

            //} while (!checkIdEtudiant(tab, id_etud));

            do { 

            //if (nom.Length>2 &&  prenom.Length>2) { 
            Console.WriteLine("Entrer le nom de l`etudiant: ");
            nom= Console.ReadLine();
            Console.WriteLine("Entrer le prenom de l`etudiant: ");
            prenom = Console.ReadLine();
                }while (nom.Length < 2 && prenom.Length < 2) ;

            etudiants[nbrEtudiants].Id_etudiant = id_etud;
            etudiants[nbrEtudiants].Nom_etudiant = nom;
            etudiants[nbrEtudiants].Prenom_etudiant= prenom;

            etudiants[nbrEtudiants].Cours_etudiants = new Cours[4];

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Entrer le id de cours: ");
                etudiants[nbrEtudiants].Cours_etudiants[i].Id_cours = int.Parse(Console.ReadLine());
                do {
                    Console.WriteLine("Entrer les notes des cours ");
                    etudiants[nbrEtudiants].Cours_etudiants[i].Note_etudiant = double.Parse(Console.ReadLine());
                    } while (etudiants[nbrEtudiants].Cours_etudiants[i].Note_etudiant<0 && etudiants[nbrEtudiants].Cours_etudiants[i].Note_etudiant >100);
            }

            nbrEtudiants++;

        }//ajoutEtudiant

        public static void afficherEtudiantFormatDetaille()
        {
            Console.WriteLine();
            Console.WriteLine("*********** Liste des etudiants *************");
            for (int i = 0; i < nbrEtudiants; i++)
            {
                Console.WriteLine("id: " + etudiants[i].Id_etudiant + " nom: " + etudiants[i].Nom_etudiant + " prenom: " + etudiants[i].Prenom_etudiant);
            }
        }

        public static void afficherEtudiantFormatabrege()
        {
            Console.WriteLine();
            Console.WriteLine("*********** Liste des etudiants abreges *************");
            for (int i = 0; i < nbrEtudiants; i++)
            {
                Console.WriteLine("id: " + etudiants[i].Id_etudiant + " nom: " + etudiants[i].Nom_etudiant.Substring(0, 2) + " prenom: " + etudiants[i].Prenom_etudiant.Substring(0, 2));
            }
        }

        static void afficherCoursParEtudiant(Etudiant[] tab)
        {
            Console.WriteLine();
            Console.WriteLine("*********** Liste des cours par etudiant *************");
            string nom;
            Console.WriteLine("Entrer le nom d`etudiant que vous voulez afficher");
            nom = Console.ReadLine();

            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i].Nom_etudiant.ToLower() == nom.ToLower())
                {
                    for (int j = 0; j <4; j++)
                    {
                        Console.WriteLine(tab[i].Cours_etudiants[j].Id_cours);
                        Console.WriteLine(tab[i].Cours_etudiants[j].Nom_cours);
                        Console.WriteLine(tab[i].Cours_etudiants[j].Note_etudiant);
                    }
                }
            }
        }

        static void supprimerEtudiant(Etudiant[] etud)
        {
            int id;
            Console.WriteLine("Entrer le id du client que vous voulez supprimer: ");
            id = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < 1; i++)
            {
                if (etud[i].Id_etudiant == id)
                {
                    etud[i].Id_etudiant = 0;
                    etud[i].Nom_etudiant = "";
                    etud[i].Prenom_etudiant = "";
                    Console.WriteLine("Etudiant supprime!");
                }
                else
                {
                    Console.WriteLine("Non trouver");
                }

            }
        }

        public static double calculerMoyenne()
        {
            double moyenne = 0;

            for (int i = 0; i < etudiants.Length; i++)
            {
                {
                    for (int j = 0; j < 4; j++)
                    {

                        moyenne += etudiants[i].Cours_etudiants[j].Note_etudiant / 4;
                        
                    }
                }
            }

            return moyenne;
        }







    }
}
