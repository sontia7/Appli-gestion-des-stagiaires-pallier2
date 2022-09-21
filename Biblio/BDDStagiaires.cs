using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Biblio
{
    internal class BDDStagiaires : DbContext 
    {
        #region Emplacement de la base de données
        internal static string Emplacement => Path.Combine(Directory.GetCurrentDirectory(), NomFichier);
        internal static string NomFichier { get; private set; } = "Stagiaires_BD.db";
        #endregion

        #region Tables de la BDD
        internal DbSet<Stagiaire> Stagiaires { get; set; }
        #endregion

        #region Méthodes d'initialisation de la base de données
        //Constructeurs de la base de données
        //Permet de créer une nouvelle base de données avec le nom par défaut (voir NomFichier)
        internal BDDStagiaires() : base() { }
        //Permet de créer/ouvrir une base de données avec le nom de fichier spécifié.
        internal BDDStagiaires(string nomFichier) : base() { NomFichier = nomFichier; }

        /// <summary>
        /// Méthode de configuration de la connexion à la base de données.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Utilisation de SQLite avec un emplacement par défaut pour la BDD lié à l'emplacement du projet
            optionsBuilder.UseSqlite($@"Data Source={Emplacement}");
        }

        /// <summary>
        /// Méthode contenant le code lié aux contraintes du modèle de données et aux données présentes par défaut
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Contraintes liées au modèle de la BDD

            #endregion

            #region Données présentes par défaut dans la BDD (lors de sa création uniquement)
            modelBuilder.Entity<Stagiaire>().HasData(
                new Stagiaire() { ID = 1, Matricule = "STG001", Login = "li@nel", MotDePasse = "lionelsontia", Cni = "12345678953", Adresse = "5434 Tsinga", Etablissement = "Mons", Niveau = true, Lieu = "RANDSATD", Ville = Villes.Tournai, Theme = "APPLICATION DE GESTION DU PERSONNEL : CAS DE CONDORCET", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                 new Stagiaire() { ID = 2, Matricule = "STG002", Login = "Luc@s", MotDePasse = "gandiapolmd", Cni = "12345678953", Adresse = "Rue Morel", Etablissement = "EPHEC", Niveau = true, Lieu = "COLRUYT", Ville = Villes.Tournai, Theme = "ROBOTISATION : CAS DE EPHEC", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                  new Stagiaire() { ID = 3, Matricule = "STG003", Login = "fredy@", MotDePasse = "garbylokjnds", Cni = "12345678953", Adresse = "Rue wisel", Etablissement = "ULIEGE", Niveau = true, Lieu = "DELHAIZE", Ville = Villes.Tournai, Theme = "APPLICATION INDUSTRIELLE : CAS DU COLRUYT", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                 new Stagiaire() { ID = 4, Matricule = "STG004", Login = "roger@", MotDePasse = "pedrogtfbvcs", Cni = "12345678953", Adresse = "Quai ivru", Etablissement = "UNAMUR", Niveau = true, Lieu = "TECHNORD", Ville = Villes.Tournai, Theme = "AUTOMATISATIONL : CAS DE CONDORCET", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                 new Stagiaire() { ID = 5, Matricule = "STG005", Login = "Rost@nd", MotDePasse = "maxenceokiu", Cni = "12345678953", Adresse = "5434 Tsinga", Etablissement = "ENS", Niveau = true, Lieu = "ADECCO", Ville = Villes.Tournai, Theme = "AUTOMATISATION : CAS DE CONDORCET", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                 new Stagiaire() { ID = 6, Matricule = "STG006", Login = "Romu@ld", MotDePasse = "rostandedrft", Cni = "12345678953", Adresse = "Rue mons", Etablissement = "UCL", Niveau = true, Lieu = "ISS", Ville = Villes.Tournai, Theme = "SECURISATION : CAS DE CONDORCET", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                  new Stagiaire() { ID = 7, Matricule = "STG007", Login = "M@rlyse", MotDePasse = "pedriedfvcxs", Cni = "12345678953", Adresse = "5434 Paris", Etablissement = "CONDORCET", Niveau = true, Lieu = "SIEMENS", Ville = Villes.Tournai, Theme = "APPLICATION DE GESTION DU PERSONNEL : CAS DE CONDORCET", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                 new Stagiaire() { ID = 8, Matricule = "STG008", Login = "Seve@", MotDePasse = "pierreaqsdfg", Cni = "12345678953", Adresse = "1000 Gans", Etablissement = "UMONS", Niveau = true, Lieu = "SNEJDER", Ville = Villes.Tournai, Theme = "APPLICATION DE GESTION DU PERSONNEL : CAS DE CONDORCET", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                 new Stagiaire() { ID = 9, Matricule = "STG009", Login = "stev@", MotDePasse = "polskakijuhy", Cni = "12345678953", Adresse = "5434 Tsinga", Etablissement = "ULIEGE", Niveau = true, Lieu = "BPOST", Ville = Villes.Tournai, Theme = "APPLICATION DE reservation : CAS DE MONS", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                 new Stagiaire() { ID = 10, Matricule = "STG0010", Login = "m@rbin", MotDePasse = "frederitgbvc", Cni = "12345678953", Adresse = "8500 Moivr", Etablissement = "UMONS", Niveau = true, Lieu = "DHL", Ville = Villes.Tournai, Theme = "APPLICATION DE GESTION DU PERSONNEL : CAS DE CONDORCET", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                 new Stagiaire() { ID = 11, Matricule = "STG0011", Login = "joy@l", MotDePasse = "pimaikjuytre", Cni = "12345678953", Adresse = "5434 Tsinga", Etablissement = "EPHEC", Niveau = true, Lieu = "TCHNORD", Ville = Villes.Tournai, Theme = "APPLICATION DE GESTION DU PERSONNEL : CAS DE LOUVAIN", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                 new Stagiaire() { ID = 12, Matricule = "STG0012", Login = "crepi@n", MotDePasse = "violayhgtrfd", Cni = "12345678953", Adresse = "5434 ivre", Etablissement = "CONDORCET", Niveau = true, Lieu = "COLRUYT", Ville = Villes.Tournai, Theme = "APPLICATION DE GESTION DU PERSONNEL : CAS DE UMONS", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                  new Stagiaire() { ID = 13, Matricule = "STG0013", Login = "max@", MotDePasse = "alexandujhg", Cni = "12345678953", Adresse = "5434 Tsinga", Etablissement = "ENS", Niveau = true, Lieu = "DELHAIZE", Ville = Villes.Tournai, Theme = "APPLICATION DE SANTE : CAS DE ICHEC", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
                 new Stagiaire() { ID = 14, Matricule = "STG0014", Login = "lil@", MotDePasse = "spinewynpmlo", Cni = "12345678953", Adresse = "5692 ath", Etablissement = "CONDORCET", Niveau = true, Lieu = "CAMTEL", Ville = Villes.Tournai, Theme = "ROBOTISATION: CAS DE ULIEGE", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 },
             new Stagiaire() { ID = 15, Matricule = "STG0015", Login = "sophi@l", MotDePasse = "maryliseikju", Cni = "12345678953", Adresse = "1256 Leuze", Etablissement = "ENS", Niveau = true, Lieu = "CAMTEL", Ville = Villes.Tournai, Theme = "APPLICATION DE GESTION DU PERSONNEL : CAS DE CONDORCET", Domaine = Domaines.Informatiques, Datedebut = new DateTime(2022, 8, 22), Datefin = new DateTime(2022, 11, 22), Note = 17 }

            );
            #endregion
        }
        #endregion

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        internal Stagiaire AjouterStagiaire(string matricule, string login, string motdepasse, string cni, string adresse, string etablissement, bool niveau, string lieu, Villes ville, string theme, Domaines domaine, DateTime dateDebut, DateTime dateFin, int note)
        {
            //Gestion des erreurs
            if (login == null || login == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterStagiaire)} : La Stagiaire doit avoir un nom (valeur NULL ou chaine vide)."); }
            if (motdepasse == null || motdepasse == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterStagiaire)} : La Stagiaire doit avoir un prénom (valeur NULL ou chaine vide)."); }
            if (theme == null || theme == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterStagiaire)} : Le Stage doit avoir un thème (valeur NULL ou chaine vide)."); }
            if (lieu == null || lieu == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterStagiaire)} : Le Stage doit avoir un lieu de stage (valeur NULL ou chaine vide)."); }
            if (dateDebut == null) { throw new ArgumentNullException($"{nameof(AjouterStagiaire)} : Le Stage doit avoir une date de début (valeur NULL ou chaine vide)."); }
            if (dateFin == null) { throw new ArgumentNullException($"{nameof(AjouterStagiaire)} : Le Stage doit avoir une date de fin (valeur NULL ou chaine vide)."); }

            //Ajout du nouveau Stagiaire
            Stagiaire NouveauStagiaire = new Stagiaire() {
                Matricule = matricule,
                Login = login,
                MotDePasse = motdepasse,
                Cni = cni,
                Adresse = adresse,
                Etablissement = etablissement,
                Niveau = niveau,
                Lieu = lieu,
                Ville = ville,
                Theme = theme,
                Domaine = domaine,
                Datedebut = dateDebut,
                Datefin = dateFin,
                Note = note,
            };
            Stagiaires.Local.Add(NouveauStagiaire);
            return NouveauStagiaire;
        }

        internal void SupprimerStagiaire(Stagiaire Stagiaire)
        {
            //Gestion des erreurs
            if (Stagiaire == null) { throw new ArgumentNullException($"{nameof(SupprimerStagiaire)} : Il faut une Stagiaire en argument (valeur NULL)."); }

            //Suppression de l'auteur
            Stagiaires.Local.Remove(Stagiaire);
        }
        #endregion
    }
}
