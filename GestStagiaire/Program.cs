using Biblio;
using GestStagiaire;
using System;
using System.Collections.ObjectModel;

byte Valeur = 0;

BDDSingleton _bdd = BDDSingleton.Instance;

_bdd.ChargerDonneesStagiaire();

ReadOnlyObservableCollection<Stagiaire> ListeStagiaires = _bdd.Stagiaires;

do
{
    Console.Clear();
    Console.WriteLine("******************************************************************************************************************");
    Console.WriteLine("******************************************************************************************************************");
    Console.WriteLine("******************************************************************************************************************");
    Console.WriteLine("*********************                                                                        *********************");
    Console.WriteLine("*********************                                                                        *********************");
    Console.WriteLine("*********************                   APPLICATION DE GESTION DES STAGIAIRES                *********************");
    Console.WriteLine("*********************                                                                        *********************");
    Console.WriteLine("*********************                                                                        *********************");
    Console.WriteLine("******************************************************************************************************************");
    Console.WriteLine("******************************************************************************************************************");
    Console.WriteLine("******************************************************************************************************************");

    Console.WriteLine("\n");
    Console.WriteLine("\t Liste complète des stagiaires enregistrés\n");

    Console.WriteLine(Stagiaire.DetailsEntetes);
    foreach (Stagiaire stag in ListeStagiaires) { Console.WriteLine($"{stag.Details}"); }

    Console.WriteLine("\n\n\t\t [1]. Ajouter un stagiaire");
    Console.WriteLine("\t\t [2]. Supprimer un stagiaire");
    Console.WriteLine("\t\t [3]. Afficher la liste triée ......");
    Console.WriteLine("\t\t [4]. Afficher la liste uniquement ......");
    Console.WriteLine("\t\t [5]. Retour au menu principal");

    Console.Write("\n\t\t\t ---> REPONSE : ");
    while (!byte.TryParse(Console.ReadLine(), out Valeur) || Valeur < 1 || Valeur > 5)
    {
        Console.WriteLine($"Erreur, le nombre doit être compris entre 1 et 5, veuillez recommencer :");
    }

    switch (Valeur)
    {
        #region 1.Ajouter un nouveau stagiaire
        case 1:
            Console.Clear();

            Console.WriteLine("\n\n");
            Console.WriteLine("\t Enregistrement d'un nouveau stagiaire\n");
            
            Stagiaire NouveauStagiaire = _bdd.AjouterStagiaire("STG002", "li@nel", "lionelsontia", "12345678953", "5434 Tsinga", "ENS", true, "CAMTEL", Villes.Tournai, "APPLICATION DE GESTION DU PERSONNEL : CAS DE CAMTEL", Domaines.Informatiques, new DateTime(2022, 8, 22), new DateTime(2022, 11, 22), 17);
            //Stagiaire NouveauStagiaire = new();
            NouveauStagiaire.Matricule = Lire.UnString("Veuillez entrer un matricule : ");
            Lire.WhileTryCatch(() => { NouveauStagiaire.Login = Lire.UnString("Veuillez entrer un login : "); });
            Lire.WhileTryCatch(() => { NouveauStagiaire.MotDePasse = Lire.UnString("Veuillez entrer un mot de passe : "); });
            Lire.WhileTryCatch(() => { NouveauStagiaire.Cni = Lire.UnString("Veuillez entrer un numéro de CNI :"); });
            NouveauStagiaire.Adresse = Lire.UnString("Veuillez entrer une adresse :");
            NouveauStagiaire.Etablissement = Lire.UnString("Veuillez entrer un établissement :");
            NouveauStagiaire.Niveau = Lire.UnBooleen("Veuillez choisir votre niveau : ", "Niveau erronné, veuillez choisir un niveau", "B", "M");
            NouveauStagiaire.Lieu = Lire.UnString("Veuillez entrer un lieu de stage : ");
            Console.WriteLine("Choix de la Ville : ");
            NouveauStagiaire.Ville = Lire.UnEnumere<Villes>();
            NouveauStagiaire.Theme = Lire.UnString("Veuillez entrer le thème de stage :");
            Console.WriteLine("Choix du Domaine de stage : ");
            NouveauStagiaire.Domaine = Lire.UnEnumere<Domaines>();
            
            DateTime dated = Lire.UnDateTime("Veuillez entrer une date de début :");
            while (dated.Year < 1950)
            {
                Console.WriteLine("L'année de stage doit être supérieure ou égale 1950. Bien vouloir reprendre : ");
                dated = Lire.UnDateTime("Veuillez entrer une date de début :");
            }
            NouveauStagiaire.Datedebut = dated;

            DateTime datef = Lire.UnDateTime("Veuillez entrer une date de fin :");
            while (datef.Year < dated.Year && datef.Month < dated.Month)
            {
                Console.WriteLine("La date de fin de stage doit être supérieure à la date de début de stage. Bien vouloir reprendre : ");
                datef = Lire.UnDateTime("Veuillez entrer une date de fin :");
            }
            
            NouveauStagiaire.Datefin = datef;

            Lire.WhileTryCatch(() => { NouveauStagiaire.Note = Lire.LireNote("Veuillez entrer une note : ", 0, 20); });
            
            _bdd.SauvegarderModificationsStagiaire();
            break;
        #endregion
        #region 2.Supprimer un stagiaire
        case 2:
            Console.Clear();

            Console.WriteLine("\n\n");

            if (ListeStagiaires.Count > 0)
            {
                foreach (Stagiaire stag in ListeStagiaires) { Console.WriteLine($"{ListeStagiaires.IndexOf(stag)} : {stag.NomComplet}."); }
                _bdd.SupprimerStagiaire(ListeStagiaires[Lire.UnByte("Veuillez faire un choix :", byte.MinValue, (byte)(ListeStagiaires.Count - 1))]);
                _bdd.SauvegarderModificationsStagiaire();
            }
            else { Console.WriteLine("Liste vide, rien à supprimer."); }
            break;
        #endregion
        #region 3.Afficher la liste triée .............
        case 3:
            Console.WriteLine("\n\n\t [1]. Par Défaut");
            Console.WriteLine("\t [2]. Par note croissant");
            Console.WriteLine("\t [3]. Par note décroissant");
            Console.WriteLine("\t [4]. Par date de début croissante");
            Console.WriteLine("\t [5]. Par date de fin décroissante");
            Console.Write("\n\t\t ---> REPONSE : ");
            while (!byte.TryParse(Console.ReadLine(), out Valeur) || Valeur < 1 || Valeur > 5)
            {
                Console.WriteLine($"Erreur, le nombre doit être compris entre 1 et 5, veuillez recommencer :");
            }

            Console.WriteLine("\n\t Liste des stagiaires triée par ordre alphabétique\n");
            Console.WriteLine(Stagiaire.DetailsEntetes);
            if (Valeur == 1)
            {
                foreach (Stagiaire stag in ListeStagiaires) { Console.WriteLine($"{stag.Details}"); }
            }
            else if (Valeur == 2)
            {
                var maListe_Natio = ListeStagiaires.OrderBy(stag => stag.Note).ToList();
                foreach (Stagiaire s in maListe_Natio) { Console.WriteLine($"{s.Details}"); }
            }
            else if (Valeur == 3)
            {
                var maListe_Natio = ListeStagiaires.OrderByDescending(stag => stag.Note).ToList();
                foreach (Stagiaire s in maListe_Natio) { Console.WriteLine($"{s.Details}"); }
            }
            else if (Valeur == 4)
            {
                var maListe_Natio = ListeStagiaires.OrderBy(stag => stag.Datedebut).ToList();
                foreach (Stagiaire s in maListe_Natio) { Console.WriteLine($"{s.Details}"); }
            }
            else if (Valeur == 5)
            {
                var maListe_Natio = ListeStagiaires.OrderByDescending(stag => stag.Datefin).ToList();
                foreach (Stagiaire s in maListe_Natio) { Console.WriteLine($"{s.Details}"); }
            }

            Console.WriteLine("\n\tAppuyer sur une touche pour retourner\n");
            Console.ReadLine();
            break;
        #endregion
        #region 4.Afficher la liste uniquement ..........
        case 4:
            Console.WriteLine("\n\n\t [1]. Par Ville");
            Console.WriteLine("\t [2]. Par Niveau");
            Console.WriteLine("\t [3]. Par Domaine");
            Console.Write("\n\t\t ---> REPONSE : ");
            while (!byte.TryParse(Console.ReadLine(), out Valeur) || Valeur < 1 || Valeur > 3)
            {
                Console.WriteLine($"Erreur, le nombre doit être compris entre 1 et 3, veuillez recommencer :");
            }

            Console.WriteLine("\n\t Liste des stagiaires triée par ordre alphabétique\n");
            if (Valeur == 1)
            {
                Villes ville = Lire.UnEnumere<Villes>();

                // Create the query.
                Console.WriteLine(Stagiaire.DetailsEntetes);
                foreach (Stagiaire stag in ListeStagiaires) { 
                    if(stag.Ville == ville)
                        Console.WriteLine($"{stag.Details}"); 
                }
            }   
            else if (Valeur == 2)
            {
                bool niveau = Lire.UnBooleen("Veuillez choisir un niveau : ", "Niveau erronné, veuillez choisir un niveau", "B", "M");

                // Create the query.
                Console.WriteLine(Stagiaire.DetailsEntetes);
                foreach (Stagiaire stag in ListeStagiaires)
                {
                    if (stag.Niveau == niveau)
                        Console.WriteLine($"{stag.Details}");
                }
            }  
            else if (Valeur == 3)
            {
                Domaines domaine = Lire.UnEnumere<Domaines>();

                // Create the query.
                Console.WriteLine(Stagiaire.DetailsEntetes);
                foreach (Stagiaire stag in ListeStagiaires)
                {
                    if (stag.Domaine == domaine)
                        Console.WriteLine($"{stag.Details}");
                }
            }

            Console.WriteLine("\n\tAppuyer sur une touche pour retourner\n");
            Console.ReadLine();
            break;
            #endregion
    }
} while (Valeur != 5);
