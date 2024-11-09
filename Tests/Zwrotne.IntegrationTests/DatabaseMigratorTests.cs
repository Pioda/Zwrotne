using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Zwrotne.Infrastructure;

namespace Zwrotne.IntegrationTests;

[Collection(Constants.IntegrationTests)]
public class DatabaseMigratorTests
{
    private TestsBase Base;
    public DatabaseMigratorTests(TestsBase @base)
    {
        Base = @base;
    }

    [Fact(DisplayName ="Check Database has been Setup")]
    public async Task DatbaseContainsSingleEntryAtStart()
    {
        var db = Base.serviceProvider.GetRequiredService<ZwrotneDbContext>();
        var entries = await db.FeatureRequests.ToListAsync();
        entries.Should()
            .HaveCount(1);
    }
}
