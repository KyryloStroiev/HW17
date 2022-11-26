using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3;

internal class User
{

    public int Id { get; set; }
    public string FullName { get; set; }
    public double LocationLatitude { get; set; }
    public double LocationLongitude { get; set; }
    public string AboutPersone { get; set; }
    public List<string> FriendsPersone { get; set; } 
    public User()
    {

    }

    public User (int id, string fullName, double locationlatitude, string aboutPersone, List<string> friendsPersone, double locationLongitude)
    {
        Id = id;
        FullName = fullName;
        LocationLatitude = locationlatitude;
        AboutPersone = aboutPersone;
        FriendsPersone = friendsPersone;
        LocationLongitude = locationLongitude;
    }
}
public class Person1
{
    public int Id { get; set; }
    public List<string> Phones { get; set; }
    public Person1()
    {

    }
    public Person1(int id, List<string> phone)
    {
        Id = id;
        Phones = phone;
    }
}