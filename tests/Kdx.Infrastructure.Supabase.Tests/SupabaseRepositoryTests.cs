using Kdx.Contracts.DTOs;
using Kdx.Infrastructure.Supabase.Repositories;
using Xunit;

namespace Kdx.Infrastructure.Supabase.Tests;

/// <summary>
/// SupabaseRepository統合テスト
/// </summary>
public class SupabaseRepositoryTests : TestBase
{
    private readonly ISupabaseRepository _repository;

    public SupabaseRepositoryTests()
    {
        _repository = new SupabaseRepository(SupabaseClient);
    }

    #region Company Tests

    [Fact]
    public async Task GetCompaniesAsync_ShouldReturnList()
    {
        // Act
        var companies = await _repository.GetCompaniesAsync();

        // Assert
        Assert.NotNull(companies);
        Assert.IsType<List<Company>>(companies);
    }

    [Fact]
    public async Task AddAndDeleteCompany_ShouldSucceed()
    {
        // Arrange
        var testCompany = new Company
        {
            CompanyName = $"Test Company {Guid.NewGuid()}",
            CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
        };

        // Act - Add
        var newId = await _repository.AddCompanyAsync(testCompany);
        Assert.True(newId > 0, "Company ID should be greater than 0");

        // Act - Verify exists
        var companies = await _repository.GetCompaniesAsync();
        var addedCompany = companies.FirstOrDefault(c => c.Id == newId);
        Assert.NotNull(addedCompany);
        Assert.Equal(testCompany.CompanyName, addedCompany.CompanyName);

        // Act - Delete
        await _repository.DeleteCompanyAsync(newId);

        // Assert - Verify deleted
        companies = await _repository.GetCompaniesAsync();
        var deletedCompany = companies.FirstOrDefault(c => c.Id == newId);
        Assert.Null(deletedCompany);
    }

    #endregion

    #region PLC Tests

    [Fact]
    public async Task GetPLCsAsync_ShouldReturnList()
    {
        // Act
        var plcs = await _repository.GetPLCsAsync();

        // Assert
        Assert.NotNull(plcs);
        Assert.IsType<List<PLC>>(plcs);
    }

    #endregion

    #region Cycle Tests

    [Fact]
    public async Task GetCyclesAsync_ShouldReturnList()
    {
        // Act
        var cycles = await _repository.GetCyclesAsync();

        // Assert
        Assert.NotNull(cycles);
        Assert.IsType<List<Cycle>>(cycles);
    }

    #endregion

    #region Model Tests

    [Fact]
    public async Task GetModelsAsync_ShouldReturnList()
    {
        // Act
        var models = await _repository.GetModelsAsync();

        // Assert
        Assert.NotNull(models);
        Assert.IsType<List<Model>>(models);
    }

    #endregion

    #region Complex Query Tests (WHERE clause fixes)

    [Fact]
    public async Task GetCylinderControlBoxesAsync_WithMultipleConditions_ShouldNotThrowParseError()
    {
        // Arrange - この test は WHERE 句が正しく動作することを確認
        int testPlcId = 1;
        int testCylinderId = 1;

        // Act & Assert - Parse error が発生しないことを確認
        var exception = await Record.ExceptionAsync(async () =>
        {
            var boxes = await _repository.GetCylinderControlBoxesAsync(testPlcId, testCylinderId);
            Assert.NotNull(boxes);
        });

        Assert.Null(exception);
    }

    [Fact]
    public async Task GetMachineByIdAsync_WithMultipleConditions_ShouldNotThrowParseError()
    {
        // Arrange
        int testNameId = 1;
        int testDriveSubId = 1;

        // Act & Assert
        var exception = await Record.ExceptionAsync(async () =>
        {
            var machine = await _repository.GetMachineByIdAsync(testNameId, testDriveSubId);
            // 結果がnullでも、Parse errorが発生しなければOK
        });

        Assert.Null(exception);
    }

    [Fact]
    public async Task GetCylinderIOsAsync_WithMultipleConditions_ShouldNotThrowParseError()
    {
        // Arrange
        int testCylinderId = 1;
        int testPlcId = 1;

        // Act & Assert
        var exception = await Record.ExceptionAsync(async () =>
        {
            var cylinderIOs = await _repository.GetCylinderIOsAsync(testCylinderId, testPlcId);
            Assert.NotNull(cylinderIOs);
        });

        Assert.Null(exception);
    }

    [Fact]
    public async Task GetIOCylindersAsync_WithMultipleConditions_ShouldNotThrowParseError()
    {
        // Arrange
        string testIOAddress = "X0000";
        int testPlcId = 1;

        // Act & Assert
        var exception = await Record.ExceptionAsync(async () =>
        {
            var ioCylinders = await _repository.GetIOCylindersAsync(testIOAddress, testPlcId);
            Assert.NotNull(ioCylinders);
        });

        Assert.Null(exception);
    }

    [Fact]
    public async Task GetMnemonicDevicesByMnemonicAsync_WithMultipleConditions_ShouldNotThrowParseError()
    {
        // Arrange
        int testPlcId = 1;
        int testMnemonicId = 1;

        // Act & Assert
        var exception = await Record.ExceptionAsync(async () =>
        {
            var devices = await _repository.GetMnemonicDevicesByMnemonicAsync(testPlcId, testMnemonicId);
            Assert.NotNull(devices);
        });

        Assert.Null(exception);
    }

    [Fact]
    public async Task GetIOInterlocksAsync_WithMultipleConditions_ShouldNotThrowParseError()
    {
        // Arrange
        string testIOAddress = "X0000";
        int testPlcId = 1;

        // Act & Assert
        var exception = await Record.ExceptionAsync(async () =>
        {
            var interlocks = await _repository.GetIOInterlocksAsync(testIOAddress, testPlcId);
            Assert.NotNull(interlocks);
        });

        Assert.Null(exception);
    }

    #endregion

    #region Delete Operations with Complex WHERE Tests

    [Fact]
    public async Task DeleteInterlockIOAsync_WithThreeConditions_ShouldNotThrowParseError()
    {
        // Arrange
        var testInterlockIO = new InterlockIO
        {
            PlcId = 999,
            IOAddress = "X9999",
            InterlockConditionId = 999
        };

        // Act & Assert - このテストではParse errorが発生しないことを確認
        var exception = await Record.ExceptionAsync(async () =>
        {
            await _repository.DeleteInterlockIOAsync(testInterlockIO);
        });

        // Parse errorでなければOK（存在しないレコードの削除は成功する）
        Assert.Null(exception);
    }

    [Fact]
    public async Task RemoveCylinderIOAssociationAsync_WithThreeConditions_ShouldNotThrowParseError()
    {
        // Arrange
        int testCylinderId = 999;
        string testIOAddress = "X9999";
        int testPlcId = 999;

        // Act & Assert
        var exception = await Record.ExceptionAsync(async () =>
        {
            await _repository.RemoveCylinderIOAssociationAsync(testCylinderId, testIOAddress, testPlcId);
        });

        Assert.Null(exception);
    }

    [Fact]
    public async Task RemoveOperationIOAssociationAsync_WithThreeConditions_ShouldNotThrowParseError()
    {
        // Arrange
        int testOperationId = 999;
        string testIOAddress = "X9999";
        int testPlcId = 999;

        // Act & Assert
        var exception = await Record.ExceptionAsync(async () =>
        {
            await _repository.RemoveOperationIOAssociationAsync(testOperationId, testIOAddress, testPlcId);
        });

        Assert.Null(exception);
    }

    #endregion
}
