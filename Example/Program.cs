// See https://aka.ms/new-console-template for more information
using Example;
using Example.Datas;
using Newtonsoft.Json;

var personalUsers = JsonConvert.DeserializeObject<IList<Personal>>(PersonalDatas.PersonalJson);
var studentUsers = JsonConvert.DeserializeObject<IList<Student>>(StudentDatas.StudentJson);
var jobberUsers = JsonConvert.DeserializeObject<IList<Jobber>>(JobberDatas.JobberJson);

IDictionary<string,IList<string>> indexes =new Dictionary<string,IList<string>>();
IDictionary<string, IUser> fastList = new Dictionary<string, IUser>();

fastList.AddToDictionary(personalUsers.Select(user=>(user as IUser)).ToList(),indexes);
fastList.AddToDictionary(studentUsers.Select(user => (user as IUser)).ToList(), indexes);
fastList.AddToDictionary(jobberUsers.Select(user => (user as IUser)).ToList(), indexes);


var findAll = FindByIndex("ejeannequin4z");
Console.WriteLine(JsonConvert.SerializeObject(findAll));
Console.WriteLine();




/*
Console.WriteLine(JsonConvert.SerializeObject(fastList));
Console.WriteLine();
*/

Console.WriteLine(JsonConvert.SerializeObject(indexes));
Console.ReadKey();


IList<IUser>? FindByIndex(string search)
{
    if (indexes.ContainsKey(search))
    {
        var findedKeys = indexes[search];
        return findedKeys.Select(key => fastList[key]).ToList();
    }
    return null;
}


/*
var findAll = FindByIndex("Dugall");
Console.WriteLine(JsonConvert.SerializeObject(findAll));
*/

/*
var findedListWithPredicate = personalUsers.FindAll(user => user.FirstName == "Dugall" || user.LastName == "Dugall");
Console.WriteLine(JsonConvert.SerializeObject(findedListWithPredicate));
*/

