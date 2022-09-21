using System.ComponentModel;
using System.Reflection;

namespace Biblio
{
    public enum Domaines
    {
        Informatiques,
        [Description("Electromécanique")]
        Electromecanique,
        Chimie,
        [Description("Kinésitherapie")]
        Kinesitherapie,
        [Description("Aéronotique")]
        Aeronotique,
        Topographie
    }

    public enum Villes
    {
        [Description("Tournaï")]
        Tournai,
        Mons,
        Charleroi,
        BruxelleCentral,
        Ostende,
        Gand
    }

    public static class EnumExtensions
    {
        /// <summary>
        /// Permet de récupérer la description associée à une valeur d'énuméré
        /// Méthode d'extension, donc appelée avec un . après le nom de la variable énumérée.
        /// </summary>
        /// <param name="GenericEnum"></param>
        /// <returns>La description de la valeur d'énuméré</returns>
        public static string GetDescription(this Enum enumValue) =>
            enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .First()
                    .GetCustomAttribute<DescriptionAttribute>()?
                    .Description
                    ?? enumValue.ToString();
    }
}