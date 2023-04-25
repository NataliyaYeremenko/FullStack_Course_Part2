using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;

namespace Yeremenko_HW5.Models
{
    public class Friend
    {
        [Required(ErrorMessage = "ID field is required"), Range(0,10000,ErrorMessage = "ID should be between 1 and 10000")]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Friend Name Empty Not Allowed"), MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Place { get; set; }

        private static readonly string[] Names = new[]
        {
        "Nataliia", "Roman", "Artem", "Olha", "Elen", "Mia", "Oksana", "Tetiana", "Daniil", "Fedir", "Lev"
        };
        private static readonly string[] Places = new[]
        {
        "Lviv", "Odesa", "Borshchahivkа", "Vinnytsia", "Rivne", "Zhytomyr", "Kharkiv"
        };

        public static List<Friend> friendsList = new List<Friend>();

        public static void GenerateRandomFriendsList(int size)
        {
            int Id = 0;
            friendsList = Enumerable.Range(1, size).Select(index => new Friend
            {
                Name = Names[Random.Shared.Next(Names.Length)],
                Place = Places[Random.Shared.Next(Places.Length)],
                Id = ++Id//GenerateId()
            })
            .ToList();
        }

        public static string GenerateId()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(12)
                .ToList().ForEach(e => builder.Append(e));
            string id = builder.ToString();
            return id;
        }
    }
}
