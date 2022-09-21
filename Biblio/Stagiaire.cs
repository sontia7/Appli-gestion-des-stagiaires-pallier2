
namespace Biblio
{
	public class Stagiaire
	{
        public static readonly DateTime DateNaissanceMIN = new DateTime(1950, 1, 1); // chqamp statique en lecture seule
        public static readonly byte NumeroTelephoneLongueurMIN = 11;
        public static readonly DateTime DateMIN = new DateTime(1950, 1, 1);

        #region Informations personnelles du stagiaire
        public string Matricule { get; set; }

        private string _Login = string.Empty;
        public string Login
        {
            get => _Login;
            set
            {
                if (value == null || value == string.Empty) { throw new ArgumentNullException("Le login ne peut pas être une valeur vide !"); }
                if (!value.Contains("@")) { throw new ArgumentException("Le login doit contenir au moins un @ !"); }
                _Login = value;
            }
        }

        private string _MotDePasse = string.Empty;
        public string MotDePasse
        {
            get => _MotDePasse;
            set
            {
                if (value == null || value == string.Empty) { throw new ArgumentNullException("Le mot de passe ne peut pas être une valeur vide !"); }
                if (value.Length < 7) {   throw new ArgumentException($"Le mot de passe doit être de longueur minimum de 7 !"); }
                _MotDePasse = value;
            }
        }

        private string _Cni = string.Empty;
        public string Cni
        {
            get => _Cni;
            set
            {
                if (value == null || value == string.Empty) { throw new ArgumentNullException("Le numéro de cni ne peut pas être une valeur vide !"); }
                if (value.Length != 11) { throw new ArgumentException($"Le numéro de cni doit être de longueur égale à 11 !"); }
                _Cni = value;
            }
        }
        public string Adresse { get; set; }
        public string Etablissement { get; set; }
        public bool Niveau { get; set; }
        #endregion

        #region Informations liées au stage
        public string Lieu { get; set; }
        public Villes Ville { get; set; }
        public string Theme { get; set; }
        public Domaines Domaine { get; set; }

        private DateTime _Datedebut = DateTime.Now;
        public DateTime Datedebut
        {
            get => _Datedebut;
            set
            {
                if (value > DateTime.Now) { value = DateTime.Now; }
                else if (value < DateMIN) { value = DateMIN; }
                _Datedebut = value;
            }
        }

        private DateTime _Datefin = DateTime.Now;
        public DateTime Datefin
        {
            get => _Datefin;
            set
            {
                if (value > DateTime.Now) { value = DateTime.Now; }
                else if (value < DateMIN) { value = DateMIN; }
                _Datefin = value;
            }
        }

        public int Note { get; set; }
        #endregion

        public string NomComplet => $"{Matricule} ({Login}; {MotDePasse})";

        #region Propriétés Details et Resume de l'objet (et réécriturre de la méthode ToString()
        //Propriété statique utilisée dans une application console comme entête pour l'affichage des données des personnes.
        public static string DetailsEntetes
        {
            get
            {
                string Resultat = $"\n|{"Stagiaire",-30}|{"N°CNI",-10}|{"Etablissement",-15}|{"Adresse",-15}|{"Domaine",-20}|{"Niveau",-10}|{"Thème",-33}|{"Ville",-10}|{"Lieu de stage",-15}|{"Date de debut",-20}|{"Date de fin",-20}|{"Note",-5}|\n";
                Resultat = Resultat.PadRight(2 * Resultat.Length - 2, '-');
                return Resultat;
            }
        }
        public string Details => $"|{NomComplet,-30}|{Cni,-10}|{Etablissement,-15}|{Adresse,-15}|{Domaine.GetDescription(),-20}|{(Niveau ? "Bachelier" : "Master"),-10}|{Theme,-33}|{Ville,-10}|{Lieu,-15}|{Datedebut,-20}|{Datefin,-20}|{Note,-5}|";
       public override string ToString() => Details; //Réécriture (override) de la méthode ToString de conversion d'un objet en chaine de caractères.
        #endregion

        #region Ajout d'un identifiant pour le projet Entity Framework Core
        public int ID { get; set; }
        #endregion
    }
}
