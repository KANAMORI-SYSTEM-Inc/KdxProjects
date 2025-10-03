# KdxProjects

NuGetパッケージ群として提供されるKDXシステムのコアライブラリ。

## パッケージ一覧

| パッケージ名 | バージョン | 説明 |
|-------------|----------|------|
| **Kdx.Contracts** | 2.0.1 | DTOとインターフェースの定義 |
| **Kdx.Core** | 2.0.1 | ビジネスロジックとアプリケーションサービス |
| **Kdx.Infrastructure** | 2.0.1 | インフラストラクチャサービスの実装 |
| **Kdx.Infrastructure.Supabase** | 2.0.1 | Supabase固有のリポジトリ実装 |

## アーキテクチャ

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

```

## ビルド

```bash
# 依存関係の復元
dotnet restore

# デバッグビルド
dotnet build

# リリースビルド（NuGetパッケージ生成）
dotnet build -c Release
```

## NuGetパッケージの使用

詳細は [docs/nuget-packages-guide.md](docs/nuget-packages-guide.md) を参照してください。

### 基本的な使用例

```bash
dotnet add package Kdx.Contracts --version 1.0.0
dotnet add package Kdx.Core --version 1.0.0
dotnet add package Kdx.Infrastructure --version 1.0.0
dotnet add package Kdx.Infrastructure.Supabase --version 1.0.0
```

## 開発

### 必要な環境

- .NET 8.0 SDK
- Visual Studio 2022 または VS Code

### プロジェクト構造

```
KdxProjects/
├── src/
│   ├── Kdx.Contracts/          # DTOとインターフェース
│   ├── Kdx.Core/                # ビジネスロジック
│   ├── Kdx.Infrastructure/      # インフラストラクチャ実装
│   ├── Kdx.Infrastructure.Supabase/  # Supabase実装
├── tests/                       # テストプロジェクト（将来追加）
└── docs/                        # ドキュメント
```

### バージョニング

このプロジェクトは **Semantic Versioning (SemVer)** を採用しています。

- **MAJOR**: 破壊的変更
- **MINOR**: 後方互換性のある機能追加
- **PATCH**: 後方互換性のあるバグフィックス

### パッケージ更新

KdxProjectsを更新してKdxDesignerに反映させる方法:

**🚀 クイックスタート:**
```powershell
# バージョン1.0.1に更新する場合
.\update-kdxprojects.ps1 -NewVersion "1.0.1"
```

**📚 詳細ガイド:**
- [QUICK-UPDATE-GUIDE.md](QUICK-UPDATE-GUIDE.md) - 更新手順のクイックリファレンス
- [完全ワークフローガイド](../kdx_projects/docs/kdxprojects-update-workflow.md) - 詳細な更新手順とシナリオ別ガイド

## ライセンス

MIT License

## 関連リポジトリ

- **KdxDesigner**: WPFデスクトップアプリケーション（このパッケージの利用者）
  - https://github.com/KANAMORI-SYSTEM-Inc/KdxDesigner

## 貢献

プルリクエストは歓迎します。大きな変更の場合は、まずissueを開いて変更内容について議論してください。

---

**作成日**: 2025-10-02
**ステータス**: Active Development
