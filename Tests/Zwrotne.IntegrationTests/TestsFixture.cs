using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.MsSql;
using Xunit;
using Zwrotne.IoC;

namespace Zwrotne.IntegrationTests;
public class TestsFixture : IAsyncLifetime
{
    public IServiceProvider serviceProvider { get; private set; }

    private MsSqlContainer dbContainer;

    public async Task InitializeAsync()
    {
        dbContainer = new MsSqlBuilder().Build();
        await dbContainer.StartAsync();

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

    public async Task DisposeAsync()
    {
        await dbContainer.DisposeAsync();
    }
}

[CollectionDefinition(Constants.IntegrationTests)]
public class TestsCollectionDefinition : ICollectionFixture<TestsFixture>
{

}