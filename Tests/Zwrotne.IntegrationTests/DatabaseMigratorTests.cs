using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Zwrotne.Infrastructure;

namespace Zwrotne.IntegrationTests;

[Collection(Constants.IntegrationTests)]
public class DatabaseMigratorTests(TestsFixture fixture)
{

    [Fact(DisplayName ="Check Database has been Setup")]
    public async Task DatbaseContainsSingleEntryAtStart()
    {
        var db = fixture.serviceProvider.GetRequiredService<ZwrotneDbContext>();
        var entries = await db.FeatureRequests.ToListAsync();
        entries.Should()
            .HaveCount(1);
    }
}
