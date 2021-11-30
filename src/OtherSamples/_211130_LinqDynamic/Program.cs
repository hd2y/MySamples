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


var topic1 = freeSql.Select<Topic>()
    .AsQueryable()
    .Where(t => t.Clicks > 0)
    .Where(t => t.Title.StartsWith("new topic"))
    .Select(t => new { title = t.Title, clicks = t.Clicks })
    .First();

var topic2 = freeSql.Select<Topic>()
    .AsQueryable()
    .Where("t => t.Clicks > 0")
    .Where("t => t.Title.StartsWith(\"new topic\")")
    .Select("new{ Title as title, Clicks as clicks }")
    .First();

Console.WriteLine("default: " + JsonSerializer.Serialize(topic1));
Console.WriteLine("dynamic: " + JsonSerializer.Serialize(topic2));

public class Topic
{
    [Column(IsIdentity = true)] public int Id { get; set; }
    public string Title { get; set; }
    public int Clicks { get; set; }
}