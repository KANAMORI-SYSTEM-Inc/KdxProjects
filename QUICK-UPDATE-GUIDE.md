# KdxProjects 更新クイックガイド

## 🚀 クイックスタート（最も一般的なケース）

### バグフィックス（1.0.0 → 1.0.1）

```powershell
# 1. KdxProjectsで変更を加える
cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxProjects
# コードを編集...

# 2. 更新スクリプトを実行
.\update-kdxprojects.ps1 -NewVersion "1.0.1"

# 3. CHANGELOG.mdを編集
# docs/CHANGELOG.md を開いて変更内容を追加

# 4. KdxDesignerを更新
cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxDesigner
.\update-kdxdesigner.ps1 -NewVersion "1.0.1"

# 5. コミット
cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxProjects
git add .
git commit -m "Fix: [変更内容の説明]"
git tag -a v1.0.1 -m "Release v1.0.1"

cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxDesigner
git add src/KdxDesigner/KdxDesigner.csproj
git commit -m "Update KdxProjects packages to v1.0.1"
```

## 📊 バージョニングチートシート

| 変更タイプ | バージョン | コマンド例 |
|-----------|----------|-----------|
| 🐛 バグ修正 | `1.0.0` → `1.0.1` | `.\update-kdxprojects.ps1 -NewVersion "1.0.1"` |
| ✨ 新機能（互換） | `1.0.1` → `1.1.0` | `.\update-kdxprojects.ps1 -NewVersion "1.1.0"` |
| 💥 破壊的変更 | `1.1.0` → `2.0.0` | `.\update-kdxprojects.ps1 -NewVersion "2.0.0"` |

## 🎯 よくあるシナリオ

### シナリオ1: 単一プロジェクトのみ変更

```powershell
# 例：Kdx.Coreのみ変更した場合でも全パッケージのバージョンを統一
.\update-kdxprojects.ps1 -NewVersion "1.0.1"
```

**重要**: 1つのプロジェクトだけ変更しても、すべてのKdxパッケージは同じバージョンに更新してください。

### シナリオ2: 新しいメソッド追加（後方互換）

```powershell
# 1. 新しいメソッドを追加
# src/Kdx.Core/Application/IProcessFlowService.cs に新メソッド追加

# 2. マイナーバージョンアップ
.\update-kdxprojects.ps1 -NewVersion "1.1.0"

# 3. KdxDesignerでは新メソッドを使うか使わないかは自由
cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxDesigner
.\update-kdxdesigner.ps1 -NewVersion "1.1.0"
# そのままビルドが通る（後方互換性あり）
```

### シナリオ3: インターフェース変更（破壊的）

```powershell
# 1. インターフェースを変更
# src/Kdx.Infrastructure.Supabase/Repositories/ISupabaseRepository.cs を編集

# 2. メジャーバージョンアップ
.\update-kdxprojects.ps1 -NewVersion "2.0.0"

# 3. CHANGELOG.mdに破壊的変更を明記
# "### Breaking Changes" セクションを追加

# 4. KdxDesignerでコード修正が必要
cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxDesigner
# まずコードを修正してから...
.\update-kdxdesigner.ps1 -NewVersion "2.0.0"
```

## 🔧 手動更新（スクリプトを使わない場合）

### KdxProjects手動更新

```powershell
cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxProjects

# 1. Directory.Build.propsを編集
# <Version>1.0.1</Version> に変更

# 2. ビルド
dotnet build -c Release

# 3. ローカルフィードにコピー
Copy-Item -Path "src\Kdx.Contracts\bin\Release\*.nupkg" -Destination "C:\NuGetLocal\" -Force
Copy-Item -Path "src\Kdx.Core\bin\Release\*.nupkg" -Destination "C:\NuGetLocal\" -Force
Copy-Item -Path "src\Kdx.Infrastructure\bin\Release\*.nupkg" -Destination "C:\NuGetLocal\" -Force
Copy-Item -Path "src\Kdx.Infrastructure.Supabase\bin\Release\*.nupkg" -Destination "C:\NuGetLocal\" -Force
Copy-Item -Path "src\Kdx.Contracts.ViewModels\bin\Release\*.nupkg" -Destination "C:\NuGetLocal\" -Force
```

### KdxDesigner手動更新

```powershell
cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxDesigner

# 1. src/KdxDesigner/KdxDesigner.csproj を編集
# すべての Kdx.* パッケージのVersionを "1.0.1" に変更

# 2. キャッシュクリアと復元
dotnet nuget locals all --clear
dotnet restore

# 3. ビルド
dotnet build -c Release
```

## ⚠️ トラブルシューティング

### エラー: パッケージが見つからない

```powershell
# 解決策1: ローカルフィードを確認
dir C:\NuGetLocal\*.nupkg

# 解決策2: NuGetキャッシュをクリア
dotnet nuget locals all --clear

# 解決策3: nuget.configを確認
cat nuget.config
# KdxLocal source が C:\NuGetLocal を指しているか確認
```

### エラー: ビルド失敗（破壊的変更後）

```powershell
# 1. KdxProjectsのCHANGELOG.mdを確認
cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxProjects
cat CHANGELOG.md | Select-String "Breaking" -Context 5

# 2. エラーメッセージから変更箇所を特定
# 例: "メソッド 'GetProcessDetails' が見つかりません"

# 3. コードを修正
# KdxDesigner側のコードを新しいインターフェースに合わせる

# 4. 再ビルド
cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxDesigner
dotnet build -c Release
```

## 📝 CHANGELOG.md テンプレート

### パッチリリース（1.0.0 → 1.0.1）

```markdown
## [1.0.1] - 2025-10-XX

### Fixed
- ProcessFlowService: 循環参照チェックのバグを修正
- InterlockValidationService: NullReferenceExceptionを修正
```

### マイナーリリース（1.0.1 → 1.1.0）

```markdown
## [1.1.0] - 2025-10-XX

### Added
- IProcessFlowService: GetProcessTree メソッドを追加
- ProcessFlowService: プロセスツリー構造の取得機能を実装

### Changed
- IInterlockValidationService: バリデーションメッセージを改善
```

### メジャーリリース（1.1.0 → 2.0.0）

```markdown
## [2.0.0] - 2025-10-XX

### Breaking Changes
⚠️ **このバージョンには破壊的変更が含まれています**

- IAccessRepositoryとSupabaseRepositoryAdapterを削除し、ISupabaseRepositoryを直接使用するように変更
  - 変更前: `services.AddScoped<IAccessRepository, SupabaseRepositoryAdapter>()`
  - 変更後: `services.AddScoped<ISupabaseRepository, SupabaseRepository>()`
- すべてのメソッドが非同期に統一
  - 同期メソッドが必要な場合は`Task.Run().GetAwaiter().GetResult()`を使用

### Migration Guide
1. DI登録を`IAccessRepository`から`ISupabaseRepository`に変更
2. コンストラクタで`ISupabaseRepository`を受け取るように変更
3. メソッド呼び出しを非同期メソッド(`*Async`)に変更
4. メソッドを含むクラスに `async` キーワードを追加

### Added
- 新しい非同期APIサポート
```

## ✅ リリースチェックリスト

### KdxProjects
- [ ] コード変更完了
- [ ] ビルド成功
- [ ] Directory.Build.props更新
- [ ] CHANGELOG.md更新
- [ ] NuGetパッケージ生成確認（5個の.nupkg）
- [ ] ローカルフィードにコピー
- [ ] コミット & タグ作成

### KdxDesigner
- [ ] .csproj更新
- [ ] NuGetキャッシュクリア
- [ ] パッケージ復元成功
- [ ] ビルド成功
- [ ] アプリケーション起動テスト
- [ ] 主要機能テスト
- [ ] コミット

## 🔗 詳細ドキュメント

より詳しい情報は以下を参照：
- [kdxprojects-update-workflow.md](../kdx_projects/docs/kdxprojects-update-workflow.md) - 完全なワークフローガイド
- [CHANGELOG.md](CHANGELOG.md) - 変更履歴
- [README.md](README.md) - プロジェクト概要

---

**最終更新**: 2025-10-02
