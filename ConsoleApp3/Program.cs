
using Bogus;
using ConsoleApp3;
using System.Linq;


var faker = new Faker<User>()
    .RuleFor(u => u.Id, f => f.IndexFaker + 1)
    .RuleFor(u => u.FullName, f => f.Person.FullName)
    .RuleFor(u => u.LocationLatitude, f => f.Address.Latitude())
    .RuleFor(u => u.LocationLongitude, f => f.Address.Longitude())
    .RuleFor(u => u.AboutPersone, f => f.Lorem.Paragraph(10))
    .RuleFor(u => u.FriendsPersone, f => f.Make(5, () => f.Name.FirstName()))
    .UseSeed(123);
var users = faker.Generate(1000);

var namefriends = users.Where(u => u.FriendsPersone.Contains("German")).Take(2);


var local1 = users.OrderBy(u => u.LocationLatitude).First();
var local2 = users.OrderBy(u => u.LocationLatitude).Last();
Console.WriteLine($"Найбiльш вiдаленi: {local1.FullName} та {local2.FullName} ");

var local3 = users.OrderBy(u => u.LocationLongitude).Take(2);


var userdata = users.
    Select(u => new CounterRecord(u.Id,
    u.AboutPersone.Split(" ").Distinct().ToList(), -1, -1)).ToList();
for (int i = 0; i < userdata.Count; i++)
{
    var user = userdata[i];
    var otherusers = userdata.Except(
        new List<CounterRecord> { user }).ToList();
    for (int j = 0; j < otherusers.Count(); j++)
    {
        var otheruser = otherusers[j];
        var intersectCount = user.Words
            .Intersect(otherusers[j].Words).Count();
        if (user.Counter < intersectCount)
        {
            user = user with
            { Counter = intersectCount, OtherId = otheruser.UserId };

        };
    }
    userdata[i] = user;
}

var max = userdata.MaxBy(u => u.Counter);
Console.WriteLine($"The max intersectin is between {max.UserId} and {max.OtherId} of {max.Counter} words");

public record CounterRecord(
    int UserId, List<string> Words, int Counter, int OtherId);






