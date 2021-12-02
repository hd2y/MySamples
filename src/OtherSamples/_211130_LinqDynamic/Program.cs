// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.Json;
using FreeSql;
using FreeSql.DataAnnotations;

IFreeSql freeSql = new FreeSqlBuilder()
    .UseConnectionString(DataType.Sqlite, "Data Source=:memory:;")
    .UseAutoSyncStructure(true)
    .UseNoneCommandParameter(true)
    .Build();

freeSql.Aop.CurdBefore += (sender, eventArgs) => Console.WriteLine("sql: " + eventArgs.Sql);

freeSql.Insert(
        Enumerable.Range(1, 100)
            .Select(i => new Topic { Title = $"new topic {i}", Clicks = 100 })
            .ToList())
    .ExecuteAffrows();


var sel1 = freeSql.Select<Topic>()
    .AsQueryable()
    .Where(t => t.Clicks > 0)
    .Where(t => t.Title.StartsWith("new topic"))
    .Select(t => new { title = t.Title, clicks = t.Clicks });

var sel2 = freeSql.Select<Topic>()
    .AsQueryable()
    .Where("t => t.Clicks > 0")
    .Where("t => t.Title.StartsWith(\"new topic\")")
    .Select("new{ Title as title, Clicks as clicks }");

var topic1 = sel1.First();
var topic2 = sel2.First();

Console.WriteLine("default: " + JsonSerializer.Serialize(topic1));
Console.WriteLine("dynamic: " + JsonSerializer.Serialize(topic2));

foreach (var item in sel1)
{
    Console.WriteLine("default: " + JsonSerializer.Serialize(item));
}
foreach (var item in sel2)
{
    Console.WriteLine("default: " + JsonSerializer.Serialize(item));
}

public class Topic
{
    [Column(IsIdentity = true)] public int Id { get; set; }
    public string Title { get; set; }
    public int Clicks { get; set; }
}