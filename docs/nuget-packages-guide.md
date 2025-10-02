# KDX Projects NuGetパッケージ使用ガイド

## 概要

KDX Projectsは、以下のNuGetパッケージとして提供されています：

1. **Kdx.Contracts** - DTOとインターフェース
2. **Kdx.Core** - ビジネスロジックとアプリケーションサービス
3. **Kdx.Infrastructure** - インフラストラクチャサービスの実装
4. **Kdx.Infrastructure.Supabase** - Supabase固有のリポジトリ実装
5. **Kdx.Contracts.ViewModels** - WPF ViewModelsの契約

## ローカルNuGetフィードのセットアップ

### 1. ローカルフィードディレクトリの作成

```bash
mkdir C:\NuGetLocal
```

### 2. パッケージのコピー

```bash
# Releaseビルドからパッケージをローカルフィードにコピー
copy bin\Kdx.Contracts\Release\*.nupkg C:\NuGetLocal\
copy bin\Kdx.Core\Release\*.nupkg C:\NuGetLocal\
copy bin\Kdx.Infrastructure\Release\*.nupkg C:\NuGetLocal\
copy bin\Kdx.Infrastructure.Supabase\Release\*.nupkg C:\NuGetLocal\
copy bin\Kdx.Contracts.ViewModels\Release\*.nupkg C:\NuGetLocal\
```

### 3. NuGetソースの追加

```bash
dotnet nuget add source C:\NuGetLocal -n KdxLocal
```

または、Visual StudioのNuGetパッケージマネージャーから：
- ツール > NuGet パッケージ マネージャー > パッケージ マネージャー設定
- パッケージ ソース > 追加
- 名前: KdxLocal
- ソース: C:\NuGetLocal

## 新しいプロジェクトでの使用方法

### 基本的な使用例

```bash
# 新しいWPFプロジェクトの作成
dotnet new wpf -n MyKdxClient

# NuGetパッケージの追加
cd MyKdxClient
dotnet add package Kdx.Contracts --version 1.0.0 --source KdxLocal
dotnet add package Kdx.Core --version 1.0.0 --source KdxLocal
dotnet add package Kdx.Infrastructure --version 1.0.0 --source KdxLocal
dotnet add package Kdx.Infrastructure.Supabase --version 1.0.0 --source KdxLocal
```

### プロジェクトファイルの例

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0-windows</TargetFramework>
    <UseWPF>true</UseWPF>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Kdx.Contracts" Version="1.0.0" />
    <PackageReference Include="Kdx.Core" Version="1.0.0" />
    <PackageReference Include="Kdx.Infrastructure" Version="1.0.0" />
    <PackageReference Include="Kdx.Infrastructure.Supabase" Version="1.0.0" />
    <PackageReference Include="Kdx.Contracts.ViewModels" Version="1.0.0" />
  </ItemGroup>
</Project>
```

## パッケージの依存関係

```
Kdx.Infrastructure.Supabase
  └─ Kdx.Core
      └─ Kdx.Contracts
  └─ supabase-csharp (0.16.2)
  └─ postgrest-csharp (3.5.1)

Kdx.Infrastructure
  └─ Kdx.Core
      └─ Kdx.Contracts
  └─ Kdx.Infrastructure.Supabase

Kdx.Contracts.ViewModels
  └─ Kdx.Contracts
  └─ CommunityToolkit.Mvvm (8.4.0)
```

## 使用例

### 1. DIコンテナの設定

```csharp
using Microsoft.Extensions.DependencyInjection;
using Kdx.Contracts.Interfaces;
using Kdx.Infrastructure.Supabase.Repositories;
using Kdx.Infrastructure.Adapters;
using Kdx.Core.Application;
using Kdx.Infrastructure.Services;

var services = new ServiceCollection();

// Repository層の登録
services.AddScoped<ISupabaseRepository, SupabaseRepository>();

// Service層の登録
services.AddScoped<IProcessFlowService, ProcessFlowService>();
services.AddScoped<IInterlockValidationService, InterlockValidationService>();

var serviceProvider = services.BuildServiceProvider();
```

### 2. リポジトリの使用

```csharp
using Kdx.Infrastructure.Supabase.Repositories;
using Kdx.Contracts.DTOs;

public class MyService
{
    private readonly ISupabaseRepository _repository;

    public MyService(ISupabaseRepository repository)
    {
        _repository = repository;
    }

    public async Task ProcessDataAsync()
    {
        var companies = await _repository.GetCompaniesAsync();
        // ビジネスロジックの実装...
    }
}
```

### 3. ビジネスサービスの使用

```csharp
using Kdx.Core.Application;

public class MyViewModel
{
    private readonly IProcessFlowService _processFlowService;
    private readonly IInterlockValidationService _validationService;

    public MyViewModel(
        IProcessFlowService processFlowService,
        IInterlockValidationService validationService)
    {
        _processFlowService = processFlowService;
        _validationService = validationService;
    }

    public void LoadProcessFlow(int cycleId)
    {
        var processDetails = _processFlowService.GetProcessDetailsByCycle(cycleId);
        var connections = _processFlowService.GetConnections(cycleId);

        // ビジネスロジックの実装...
    }
}
```

## パッケージのアップデート

### バージョン番号の更新

各プロジェクトの `.csproj` ファイルの `<Version>` タグを更新します：

```xml
<Version>1.0.1</Version>
```

### パッケージの再ビルド

```bash
dotnet build -c Release
```

### ローカルフィードへのコピー

```bash
copy bin\Kdx.Contracts\Release\*.nupkg C:\NuGetLocal\
# ... 他のパッケージも同様
```

## トラブルシューティング

### パッケージが見つからない場合

1. ローカルフィードのパスを確認
```bash
dotnet nuget list source
```

2. キャッシュをクリア
```bash
dotnet nuget locals all --clear
```

3. パッケージを再インストール
```bash
dotnet restore
```

### 依存関係の競合

パッケージ間のバージョンが一致していることを確認してください。すべてのKdxパッケージは同じバージョン（1.0.0など）を使用することを推奨します。

## プライベートNuGet Serverへの公開（オプション）

### Azure Artifactsの使用

```bash
dotnet nuget push Kdx.Contracts.1.0.0.nupkg --source "AzureArtifacts" --api-key <your-api-key>
```

### GitHub Packagesの使用

```bash
dotnet nuget push Kdx.Contracts.1.0.0.nupkg --source "github" --api-key <your-github-token>
```

## まとめ

KDX ProjectsのNuGetパッケージ化により、以下のメリットが得られます：

- ✅ KdxDesignerと他のプロジェクトの完全な分離
- ✅ バージョン管理が容易
- ✅ 他のプロジェクトからの再利用が可能
- ✅ 依存関係の明確化
- ✅ 配布が簡単

## 参考資料

- [NuGet Documentation](https://docs.microsoft.com/en-us/nuget/)
- [Creating NuGet Packages](https://docs.microsoft.com/en-us/nuget/create-packages/overview-and-workflow)
- [Local NuGet Feeds](https://docs.microsoft.com/en-us/nuget/hosting-packages/local-feeds)
