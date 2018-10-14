
using System.Collections.Generic;
using System.Linq;
using WorldCup18;

public static class UserData
{
    public static List<User> Users { get; private set; }

    static UserData()
    {
        var temp = new List<User>();


        AddUser(temp);

        Users = temp.OrderBy(i => i.Name).ToList();
    }

    static void AddUser(List<User> users)
    {
        users.Add(new User()
        {
            Name = "tamir",
            Department = "Xamarin Android & Xamarin Forms Development",
            ImageUrl = "images/tamir.jpg",
         
        });

        users.Add(new User()
        {
            Name = "matan",
            Department = "Xamarin Android & Xamarin Forms Development",
            ImageUrl = "images/matan.jpg",
           

        });
        users.Add(new User()
        {
            Name = "lior",
            Department = "Xamarin Android & Xamarin Forms Development",
            ImageUrl = "images/lior.jpg",
          

        });

        users.Add(new User()
        {
            Name = "shai",
            Department = "Xamarin Android & Xamarin Forms Development",
            ImageUrl = "images/shai.jpg",
            

        }); users.Add(new User()
        {
            Name = "adam",
            Department = "Xamarin Android & Xamarin Forms Development",
            ImageUrl = "images/adam.jpg",
           

        });
        users.Add(new User()
        {
            Name = "avi",
            Department = "Xamarin Android & Xamarin Forms Development",
            ImageUrl = "images/avi.jpg",


        });
    }
}