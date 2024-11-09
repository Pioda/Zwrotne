using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.MsSql;
using Xunit;
using Zwrotne.IoC;

namespace Zwrotne.IntegrationTests;
public class TestsBase : IAsyncDisposable
{
    public Fixture fixture { get; init; }
    public IServiceProvider serviceProvider { get; init; }
    private MsSqlContainer dbContainer;
    public TestsBase()
    {
        fixture = new();
        fixture.Customize(new AutoMoqCustomization());

        dbContainer = new MsSqlBuilder().Build();
        dbContainer.StartAsync().Wait();

        string connString = dbContainer.GetConnectionString();

        Migrator.Program.Main([connString]);

        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>()
            {
                ["ConnectionStrings:DefaultConnection"] = connString
            }).Build();

        serviceProvider = new ServiceCollection()
            .Setup(config)
            .BuildServiceProvider();

    }

    public async ValueTask DisposeAsync()
    {
        await dbContainer.DisposeAsync();
    }
}


[CollectionDefinition(Constants.IntegrationTests)]
public class TestsCollectionDefinition : ICollectionFixture<TestsBase>
{

}