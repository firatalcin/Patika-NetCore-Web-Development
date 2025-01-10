using System.ComponentModel;

namespace BookStore.API.Common
{
    public enum GenreEnum
    {
        [Description("Bilim Kurgu")]
        BilimKurgu = 1,

        [Description("Tarihsel Roman")]
        TarihselRoman = 2,

        [Description("Çocuk Kitabı")]
        CocukKitabi = 3,

        [Description("Fantastik")]
        Fantastik = 4,

        [Description("Klasik")]
        Klasik = 5
    }
}
